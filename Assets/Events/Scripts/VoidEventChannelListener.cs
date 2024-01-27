using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventChannelListener : MonoBehaviour
{
    [Header("Listen to Event Channels")]
    [Tooltip("The signal to listen for")]
    [SerializeField] private VoidEventChannelSO m_EventChannel;
    [Space]
    [Tooltip("Responds to receiving signal from Event Channel")]
    [SerializeField] private UnityEvent m_Response;
    [SerializeField] private float m_Delay;

    private void OnEnable()
    {
        if (m_EventChannel != null)
            m_EventChannel.OnEventRaised += OnEventRaised;
    }

    private void OnDisable()
    {
        if (m_EventChannel != null)
            m_EventChannel.OnEventRaised -= OnEventRaised;
    }

    public void OnEventRaised()
    {
        StartCoroutine(RaiseEventDelayed(m_Delay));
    }

    private IEnumerator RaiseEventDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_Response.Invoke();
    }
}
