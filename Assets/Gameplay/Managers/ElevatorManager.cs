using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] private int m_ActualFloor;
    [SerializeField] private GameObject m_LeftDoor;
    [SerializeField] private GameObject m_RightDoor;
    [SerializeField] private GameObject m_TransporterManager;

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
        m_IsMoving = false;
        m_ActualFloor = floor;

        while (m_IsOpening)
            yield return null;

        m_IsMoving = true;

        switch(floor)
        {
            case 0:
                m_TransporterManager.GetComponent<TransporterManager>().ToBasePlant();
                break;
            case 1:
                m_TransporterManager.GetComponent<TransporterManager>().To1stFloor();
                break;
            case 2:
                m_TransporterManager.GetComponent<TransporterManager>().To2ndFloor();
                break;
        }
        m_IsMoving = false;
        m_ActualFloor = floor;
        ToggleDoors();
    }

    IEnumerator MoveDoor(GameObject door, float targetX)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = door.transform.position;
        Vector3 targetPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + targetX);
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
            StartCoroutine(MoveDoor(m_LeftDoor, -0.5f));
            StartCoroutine(MoveDoor(m_RightDoor, 0.5f));
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
