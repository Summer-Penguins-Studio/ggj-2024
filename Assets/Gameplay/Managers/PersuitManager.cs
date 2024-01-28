using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersuitManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;

    [SerializeField] private Vector3 m_1stStagePosition;
    [SerializeField] private Vector3 m_2ndStagePosition;

    [SerializeField] private VoidEventChannel m_Persuit1stStageBegin;
    [SerializeField] private VoidEventChannel m_Persuit2ndStageBegin;
    [SerializeField] private VoidEventChannel m_Persuit3rdStageBegin;
    [SerializeField] private VoidEventChannel m_Persuit1stStageEnd;
    [SerializeField] private VoidEventChannel m_Persuit2ndStageEnd;
    [SerializeField] private VoidEventChannel m_Persuit3rdStageEnd;
    [SerializeField] private VoidEventChannel m_Persuit1stInterlude;
    [SerializeField] private VoidEventChannel m_Persuit2ndInterlude;

    private void OnEnable()
    {
        if (m_Persuit1stStageBegin != null)
            m_Persuit1stStageBegin.OnEventRaised += persuit1stStageBegin;
        if (m_Persuit2ndStageBegin != null)
            m_Persuit2ndStageBegin.OnEventRaised += persuit2ndStageBegin;
        if (m_Persuit3rdStageBegin != null)
            m_Persuit3rdStageBegin.OnEventRaised += persuit3rdStageBegin;
        if (m_Persuit1stStageEnd != null)
            m_Persuit1stStageEnd.OnEventRaised += persuit1stStageEnd;
        if (m_Persuit2ndStageEnd != null)
            m_Persuit2ndStageEnd.OnEventRaised += persuit2ndStageEnd;
        if (m_Persuit3rdStageEnd != null)
            m_Persuit3rdStageEnd.OnEventRaised += persuit3rdStageEnd;
        if (m_Persuit1stInterlude != null)
            m_Persuit1stInterlude.OnEventRaised += persuit1stInterlude;
        if (m_Persuit2ndInterlude != null)
            m_Persuit2ndInterlude.OnEventRaised += persuit2ndInterlude;
    }

    private void OnDisable()
    {
        if (m_Persuit1stStageBegin != null)
            m_Persuit1stStageBegin.OnEventRaised -= persuit1stStageBegin;
        if (m_Persuit2ndStageBegin != null)
            m_Persuit2ndStageBegin.OnEventRaised -= persuit2ndStageBegin;
        if (m_Persuit3rdStageBegin != null)
            m_Persuit3rdStageBegin.OnEventRaised -= persuit3rdStageBegin;
        if (m_Persuit1stStageEnd != null)
            m_Persuit1stStageEnd.OnEventRaised -= persuit1stStageEnd;
        if (m_Persuit2ndStageEnd != null)
            m_Persuit2ndStageEnd.OnEventRaised -= persuit2ndStageEnd;
        if (m_Persuit3rdStageEnd != null)
            m_Persuit3rdStageEnd.OnEventRaised -= persuit3rdStageEnd;
        if (m_Persuit1stInterlude != null)
            m_Persuit1stInterlude.OnEventRaised -= persuit1stInterlude;
        if (m_Persuit2ndInterlude != null)
            m_Persuit2ndInterlude.OnEventRaised -= persuit2ndInterlude;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void persuit1stStageBegin()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = true;
    }

    private void persuit2ndStageBegin()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = true;
    }
    private void persuit3rdStageBegin()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = true;
    }

    private void persuit1stStageEnd()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = false;
    }
    private void persuit2ndStageEnd()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = false;
    }
    private void persuit3rdStageEnd()
    {
        m_Enemy.GetComponent<EnemyScript>().enabled = false;
    }

    private void persuit1stInterlude()
    {
        m_Enemy.GetComponent<NavMeshAgent>().enabled = false;
        m_Enemy.transform.position = m_1stStagePosition;
        m_Enemy.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void persuit2ndInterlude()
    {
        m_Enemy.GetComponent<NavMeshAgent>().enabled = false;
        m_Enemy.transform.position = m_2ndStagePosition;
        m_Enemy.GetComponent<NavMeshAgent>().enabled = true;
    }
}
