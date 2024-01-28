using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private VoidEventChannel m_TimeOut;
    [SerializeField] private VoidEventChannel m_TimeInit;

    [SerializeField] private bool m_initialized;
    [SerializeField] private float m_TotalTime;
    [SerializeField] private float m_RemainingTime;

    [SerializeField] private int m_FontSize;
    [SerializeField] private int m_FontBigSize;
    [SerializeField] private float m_FontChangeTime;

    private int m_minutes, m_seconds, m_cents;

    private void OnEnable()
    {
        if (m_TimeInit != null)
            m_TimeInit.OnEventRaised += initialize;
    }

    private void OnDisable()
    {
        if (m_TimeInit != null)
            m_TimeInit.OnEventRaised -= initialize;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_RemainingTime = m_TotalTime;
        m_Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_initialized)
        {
            m_RemainingTime -= Time.deltaTime;
            m_minutes = Mathf.RoundToInt(m_RemainingTime / 60f);
            m_seconds = Mathf.RoundToInt(m_RemainingTime - m_minutes * 60f);
            m_cents = (int)((m_RemainingTime - (int)m_RemainingTime) * 100f);
            m_Text.text = string.Format("{0:00}:{1:00}:{2:00}", m_minutes, m_seconds, m_cents);

            if (Mathf.RoundToInt(m_RemainingTime) == 0)
            {
                m_TimeOut.RaiseEvent();
            }
        }
    }

    private void initialize()
    {
        m_initialized = true;
        m_Text.enabled = true;
        StartCoroutine(ExposeTimer());
    }

    IEnumerator ExposeTimer()
    {
        float timeElapsed = 0f;
        float fullTime = m_FontChangeTime;
        while (timeElapsed < fullTime)
        {
            m_Text.fontSize = Mathf.Lerp(m_FontSize, m_FontBigSize, timeElapsed / fullTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        m_Text.fontSize = m_FontBigSize;
        timeElapsed = 0;
        while (timeElapsed < fullTime)
        {
            m_Text.fontSize = Mathf.Lerp(m_FontBigSize, m_FontSize, timeElapsed / fullTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        m_Text.fontSize = m_FontSize;
    }
}
