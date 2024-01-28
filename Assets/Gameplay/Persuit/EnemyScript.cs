using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    [SerializeField] private Transform m_Player;
    [SerializeField] GameObject transporterManager;


    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.destination = m_Player.position;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            transporterManager.GetComponent<TransporterManager>().ToHospital();
        }
    }
}
