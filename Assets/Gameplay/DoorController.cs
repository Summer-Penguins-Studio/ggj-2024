using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject m_leftDoor;
    [SerializeField] private GameObject m_rightDoor;

    [SerializeField] private VoidEventChannel m_OpenDoors;

    [SerializeField] private float m_FullRotationTime;

    private void OnEnable()
    {
        if (m_OpenDoors != null)
            m_OpenDoors.OnEventRaised += open;
    }

    private void OnDisable()
    {
        if (m_OpenDoors != null)
            m_OpenDoors.OnEventRaised -= open;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void open()
    {
        StartCoroutine(OpenDoor(m_rightDoor));
        StartCoroutine(OpenDoor(m_leftDoor));
    }

    IEnumerator OpenDoor(GameObject door)
    {
        float timeElapsed = 0f;
        while (timeElapsed < m_FullRotationTime)
        {
            door.transform.rotation = new Quaternion(0, Mathf.Lerp(0, 100, timeElapsed / m_FullRotationTime), 0, 0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        door.transform.rotation = Quaternion.Euler(100, 0, 0);
    }
}
