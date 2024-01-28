using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelUp : MonoBehaviour
{
    [SerializeField] private GameObject m_TransporterManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_TransporterManager.GetComponent<TransporterManager>().ToSuersExit();
        }
    }
}
