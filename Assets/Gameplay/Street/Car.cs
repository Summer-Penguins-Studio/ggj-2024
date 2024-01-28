using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private VoidEventChannel m_RedLight;
    [SerializeField] private VoidEventChannel m_GreenLight;

    [SerializeField] private bool m_IsGreen;
    [SerializeField] private bool m_IsMoving;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_InitX;
    [SerializeField] private int m_StopX;
    [SerializeField] private float m_RayDistance;
    [SerializeField] private Vector3 m_DirectionVector;

    private void OnEnable()
    {
        if (m_RedLight != null)
            m_RedLight.OnEventRaised += redLight;

        if (m_GreenLight != null)
            m_GreenLight.OnEventRaised += greenLight;
    }

    private void OnDisable()
    {
        if (m_RedLight != null)
            m_RedLight.OnEventRaised -= redLight;

        if (m_GreenLight != null)
            m_GreenLight.OnEventRaised -= greenLight;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left, Color.red, m_RayDistance);


        float speed = 0;

        if (FrontCheck())
        {
            speed = 0;
        } 
        else if (m_IsGreen)
        {
            speed = m_Speed;
        }
        else
        {
            int xPos = Mathf.RoundToInt(transform.position.x);
            if (xPos == m_StopX)
            {
                speed = 0;
            }
            else
            {
                speed = m_Speed;
            }
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private bool FrontCheck()
    {
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.right, out hit, m_RayDistance))
        {
            return false;
        }

        return (hit.transform.CompareTag("Car"));
    }

    private void greenLight()
    {
        m_IsGreen = true;
    }

    private void redLight()
    {
        m_IsGreen = false;
    }
}