using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] private int m_ActualFloor;
    [SerializeField] private GameObject m_LeftDoor;
    [SerializeField] private GameObject m_RightDoor;

    [SerializeField] private float m_OpeningTime;
    private bool m_IsClosed;
    private bool m_IsOpening;
    private bool m_IsMoving;
    private bool m_WithPlayer;

    public bool IsOpening => m_IsOpening;

    // Start is called before the first frame update
    void Start()
    {
        m_IsMoving = false;
        m_IsOpening = false;
        m_IsClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_WithPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeFloor(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeFloor(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeFloor(2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_WithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_WithPlayer = false;
        }
    }

    public void ChangeFloor(int floor)
    {
        if (m_IsMoving)
            return;

        if (floor == m_ActualFloor)
            return;

        ToggleDoors();
        StartCoroutine(MoveElevator(floor));
    }

    IEnumerator MoveElevator(int floor)
    {
        while (m_IsOpening)
            yield return null;

        m_IsMoving = true;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3 (startPosition.x, (3.5f * floor), startPosition.z);

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 pStartPosition = player.position;
        Vector3 pEndPosition = new Vector3(player.position.x, (3.5f * floor), player.position.z);
        while (elapsedTime < m_OpeningTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / m_OpeningTime);
            player.position = Vector3.Lerp(pStartPosition, pEndPosition, elapsedTime / m_OpeningTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        player.position = pEndPosition;
        m_IsMoving = false;
        m_ActualFloor = floor;
        ToggleDoors();
    }

    IEnumerator MoveDoor(GameObject door, float targetX)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = door.transform.position;
        Vector3 targetPosition = new Vector3(targetX, door.transform.position.y, door.transform.position.z);
        while (elapsedTime < m_OpeningTime)
        {
            door.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / m_OpeningTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        door.transform.position = targetPosition;
        m_IsOpening = false;
    }

    private void ToggleDoors()
    {
        if (m_IsOpening)
            return;

        m_IsOpening = !m_IsOpening;
        if (m_IsClosed)
        {
            StartCoroutine(MoveDoor(m_LeftDoor, -1.5f));
            StartCoroutine(MoveDoor(m_RightDoor, 1.5f));
            m_IsClosed = false;
        }
        else
        {
            StartCoroutine(MoveDoor(m_LeftDoor, -0.5f));
            StartCoroutine(MoveDoor(m_RightDoor, 0.5f));
            m_IsClosed = true;
        }
    }
}
