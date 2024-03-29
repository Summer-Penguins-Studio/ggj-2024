using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TransporterManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;

    [SerializeField] private Vector3 m_Hospital;
    [SerializeField] private Vector3 m_BasePlant;
    [SerializeField] private Vector3 m_1stFloor;
    [SerializeField] private Vector3 m_2ndFloor;
    [SerializeField] private Vector3 m_SuersExit;

    [SerializeField] private VoidEventChannel m_CarHit;

    private CameraManager m_CameraManager;

    private void OnEnable()
    {
        if (m_CarHit != null)
            m_CarHit.OnEventRaised += ToHospital;
    }

    private void OnDisable()
    {
        if (m_CarHit != null)
            m_CarHit.OnEventRaised -= ToHospital;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_CameraManager = GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToHospital()
    {
        StartCoroutine(Transport(m_Hospital, Transition.INSTANT_IN, Transition.BLACKOUT_OUT));
    }

    public void To2ndFloor()
    {
        StartCoroutine(Transport(m_2ndFloor, Transition.BLACKOUT_IN, Transition.BLACKOUT_OUT));
    }

    public void To1stFloor()
    {
        StartCoroutine(Transport(m_1stFloor, Transition.BLACKOUT_IN, Transition.BLACKOUT_OUT));
    }

    public void ToBasePlant()
    {
        StartCoroutine(Transport(m_BasePlant, Transition.BLACKOUT_IN, Transition.BLACKOUT_OUT));
    }

    public void ToSuersExit()
    {
        StartCoroutine(Transport(m_SuersExit, Transition.BLACKOUT_IN, Transition.BLACKOUT_OUT));
    }

    private IEnumerator Transport(Vector3 position, Transition initial, Transition final)
    {
        m_Player.GetComponent<FirstPersonController>().enabled = false;

        switch (initial)
        {
            case Transition.BLACKOUT_IN:
                m_CameraManager.blackoutIn();
                yield return new WaitForSeconds(1.5f);
                break;
            case Transition.BLACKOUT_OUT:
                m_CameraManager.blackoutOut();
                yield return new WaitForSeconds(1.5f);
                break;
            case Transition.INSTANT_IN:
                m_CameraManager.instantIn();
                yield return new WaitForSeconds(1f);
                break;
            case Transition.INSTANT_OUT:
                m_CameraManager.instantOut();
                yield return new WaitForSeconds(1f);
                break;
            case Transition.NONE:
                break;
        }

        m_Player.transform.position = position;

        switch (final)
        {
            case Transition.BLACKOUT_IN:
                m_CameraManager.blackoutIn();
                yield return new WaitForSeconds(1.5f);
                break;
            case Transition.BLACKOUT_OUT:
                m_CameraManager.blackoutOut();
                yield return new WaitForSeconds(1.5f);
                break;
            case Transition.INSTANT_IN:
                m_CameraManager.instantIn();
                yield return new WaitForSeconds(1f);
                break;
            case Transition.INSTANT_OUT:
                m_CameraManager.instantOut();
                yield return new WaitForSeconds(1f);
                break;
            case Transition.NONE:
                break;
        }

        m_Player.GetComponent<FirstPersonController>().enabled = true;
    }
}
