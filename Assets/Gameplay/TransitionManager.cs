using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Image m_PanelImage;

    [SerializeField] private VoidEventChannel m_GradualBlackout;
    [SerializeField] private VoidEventChannel m_Show;

    [SerializeField] private float m_GradualTime;

    private void OnEnable()
    {
        if (m_GradualBlackout != null)
            m_GradualBlackout.OnEventRaised += gradualBlackoutCaller;

        if (m_Show != null)
            m_Show.OnEventRaised += show;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator gradualBlackout()
    {
        float timeElapsed = 0;
        Color initialColor = m_PanelImage.color;
        Color endColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1);
        while (timeElapsed < m_GradualTime)
        {
            m_PanelImage.color = Color.Lerp(initialColor, endColor, timeElapsed / m_GradualTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        m_PanelImage.color = endColor;
    }

    private void gradualBlackoutCaller()
    {
        StartCoroutine(gradualBlackout());
    }

    private void blackout()
    {
        Color color = m_PanelImage.color;
        m_PanelImage.color = new Color(color.r, color.g, color.b, 1);
    }

    private void show()
    {
        Color color = m_PanelImage.color;
        m_PanelImage.color = new Color(color.r, color.g, color.b, 0);
    }
}
