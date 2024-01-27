using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : MonoBehaviour
{
    [SerializeField] private VoidEventChannel m_RedLight;
    [SerializeField] private VoidEventChannel m_GreenLight;
    [SerializeField] private bool m_Initialized;
    [SerializeField] private bool m_IsGreen;
    [SerializeField] private float m_RedTime;
    [SerializeField] private float m_GreenTime;
    [SerializeField] private float m_RemainingTime;

    // Start is called before the first frame update
    void Start()
    {
        m_RemainingTime = m_GreenTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Initialized)
            return;

        if (m_RemainingTime <= 0)
        {
            if (m_IsGreen)
            {
                m_RedLight.RaiseEvent();
                m_RemainingTime = m_RedTime;
            }
            else
            {
                m_GreenLight.RaiseEvent();
                m_RemainingTime = m_GreenTime;
            }

            m_IsGreen = !m_IsGreen;
        }

        m_RemainingTime -= Time.deltaTime;
    }
}
