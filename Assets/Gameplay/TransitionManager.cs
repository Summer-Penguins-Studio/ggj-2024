using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Image m_PanelImage;

    [SerializeField] private VoidEventChannel m_GradualBlackoutIn;
    [SerializeField] private VoidEventChannel m_GradualBlackoutOut;
    [SerializeField] private VoidEventChannel m_InstantIn;
    [SerializeField] private VoidEventChannel m_InstantOut;

    [SerializeField] private float m_GradualTime;

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
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blackout(bool fadein)
    {
        float timeElapsed = fadein ? 0 : m_GradualTime;
        Color initialColor = m_PanelImage.color;
        Color endColor = new Color(initialColor.r, initialColor.g, initialColor.b, (fadein ? 1 : 0));

        while (timeElapsed < m_GradualTime)
        {
            m_PanelImage.color = Color.Lerp(initialColor, endColor, timeElapsed / m_GradualTime);
            if (fadein)
                timeElapsed += Time.deltaTime;
            else
                timeElapsed -= Time.deltaTime;
            yield return null;
        }

        m_PanelImage.color = endColor;
    }

    private void blackoutIn()
    {
        StartCoroutine(Blackout(true));
    }
    private void blackoutOut()
    {
        StartCoroutine(Blackout(false));
    }

    private void instantIn()
    {
        Color color = m_PanelImage.color;
        m_PanelImage.color = new Color(color.r, color.g, color.b, 1);
    }
    private void instantOut()
    {
        Color color = m_PanelImage.color;
        m_PanelImage.color = new Color(color.r, color.g, color.b, 0);
    }
}
