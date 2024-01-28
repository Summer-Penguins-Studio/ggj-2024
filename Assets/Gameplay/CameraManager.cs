using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Image m_PanelImage;

    [SerializeField] private VoidEventChannel m_GradualBlackoutIn;
    [SerializeField] private VoidEventChannel m_GradualBlackoutOut;
    [SerializeField] private VoidEventChannel m_InstantIn;
    [SerializeField] private VoidEventChannel m_InstantOut;
    [SerializeField] private VoidEventChannel m_CameraShake;

    [SerializeField] private float m_GradualBlackoutTime;
    [SerializeField] private CinemachineVirtualCamera m_Camera;

    private CinemachineBasicMultiChannelPerlin m_ChannelPerlin;
    private float m_ShakingTime;
    private float m_FullShakingTime;
    private float m_InitialShakingIntensity;

    private void Awake()
    {
        m_ChannelPerlin = m_Camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnEnable()
    {
        if (m_GradualBlackoutIn != null)
            m_GradualBlackoutIn.OnEventRaised += blackoutIn;

        if (m_GradualBlackoutOut != null)
            m_GradualBlackoutOut.OnEventRaised += blackoutOut;

        if (m_InstantIn != null)
            m_InstantIn.OnEventRaised += instantIn;

        if (m_InstantOut != null)
            m_InstantOut.OnEventRaised += instantOut;

        if (m_CameraShake != null)
            m_CameraShake.OnEventRaised += CameraShake;
    }
    private void OnDisable()
    {
        if (m_GradualBlackoutIn != null)
            m_GradualBlackoutIn.OnEventRaised -= blackoutIn;

        if (m_GradualBlackoutOut != null)
            m_GradualBlackoutOut.OnEventRaised -= blackoutOut;

        if (m_InstantIn != null)
            m_InstantIn.OnEventRaised -= instantIn;

        if (m_InstantOut != null)
            m_InstantOut.OnEventRaised -= instantOut;

        if (m_CameraShake != null)
            m_CameraShake.OnEventRaised -= CameraShake;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ShakingTime > 0)
        {
            m_ShakingTime -= Time.deltaTime;
            m_ChannelPerlin.m_AmplitudeGain = Mathf.Lerp(m_InitialShakingIntensity, 0, 1 - (m_ShakingTime / m_FullShakingTime));
        }
    }

    IEnumerator Blackout(bool black)
    {
        float timeElapsed = 0;
        Color initialColor = m_PanelImage.color;
        Color endColor = new Color(initialColor.r, initialColor.g, initialColor.b, (black ? 1 : 0));

        while (timeElapsed < m_GradualBlackoutTime)
        {
            m_PanelImage.color = Color.Lerp(initialColor, endColor, timeElapsed / m_GradualBlackoutTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        m_PanelImage.color = endColor;
    }

    public void blackoutIn()
    {
        StartCoroutine(Blackout(true));
    }
    public void blackoutOut()
    {
        StartCoroutine(Blackout(false));
    }

    public void instantIn()
    {
        m_PanelImage.color = new Color(m_PanelImage.color.r, m_PanelImage.color.g, m_PanelImage.color.b, 1);
    }
    public void instantOut()
    {
        m_PanelImage.color = new Color(m_PanelImage.color.r, m_PanelImage.color.g, m_PanelImage.color.b, 0);
    }

    private void CameraShake()
    {
        ShakeCamera(5, 5, 0.5f);
    }

    private void ShakeCamera(float intensity, float frecuency, float time)
    {
        m_ChannelPerlin.m_AmplitudeGain = intensity;
        m_ChannelPerlin.m_FrequencyGain = frecuency;
        m_InitialShakingIntensity = intensity;
        m_FullShakingTime = time;
        m_ShakingTime = time;
    }
}
