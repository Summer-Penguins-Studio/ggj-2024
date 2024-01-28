using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannel m_HPInit;

    private void OnEnable()
    {
        if (m_HPInit != null)
            m_HPInit.OnEventRaised += initialize;
    }

    private void OnDisable()
    {
        if (m_HPInit != null)
            m_HPInit.OnEventRaised -= initialize;
    }

    private void initialize()
    {

    }
}
