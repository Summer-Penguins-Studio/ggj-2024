using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float m_TotalTime;
    [SerializeField] private FloatVariable m_RemainingTime;
    private int m_minutes, m_seconds, m_cents;

    // Start is called before the first frame update
    void Start()
    {
        m_RemainingTime.Value = m_TotalTime;
    }

    // Update is called once per frame
    void Update()
    {
        m_RemainingTime.Value -= Time.deltaTime;
        m_minutes = Mathf.RoundToInt(m_RemainingTime.Value / 60f);
        m_seconds = Mathf.RoundToInt(m_RemainingTime.Value - m_minutes * 60f);
        m_cents = (int)((m_RemainingTime.Value - (int)m_RemainingTime.Value) * 100f);
    }
}
