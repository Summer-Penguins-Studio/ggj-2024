using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TransporterManager : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;

    [SerializeField] private Vector3 m_Hospital;

    private CameraManager m_CameraManager;

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
        MovePlayer(m_Hospital, Transition.INSTANT_IN, Transition.BLACKOUT_OUT);
    }

    private IEnumerator initialTransit(Transition transition)
    {
        switch (transition)
        {
            case Transition.BLACKOUT_IN:
                m_CameraManager.blackoutIn();
                yield return new WaitForSeconds(90);
                break;
            case Transition.BLACKOUT_OUT:
                m_CameraManager.blackoutOut();
                yield return new WaitForSeconds(90);
                break;
            case Transition.INSTANT_IN:
                m_CameraManager.instantIn();
                yield return new WaitForSeconds(2);
                break;
            case Transition.INSTANT_OUT:
                m_CameraManager.instantOut();
                yield return new WaitForSeconds(2);
                break;
        }
    }

    private IEnumerator finalTransit(Transition transition)
    {
        switch (transition)
        {
            case Transition.BLACKOUT_IN:
                m_CameraManager.blackoutIn();
                yield return new WaitForSeconds(90);
                break;
            case Transition.BLACKOUT_OUT:
                m_CameraManager.blackoutOut();
                yield return new WaitForSeconds(90);
                break;
            case Transition.INSTANT_IN:
                m_CameraManager.instantIn();
                yield return new WaitForSeconds(2);
                break;
            case Transition.INSTANT_OUT:
                m_CameraManager.instantOut();
                yield return new WaitForSeconds(2);
                break;
        }
    }

    private void MovePlayer(Vector3 position, Transition initial, Transition final)
    {
        StartCoroutine(initialTransit(initial));
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        m_Player.transform.position = position;
        StartCoroutine(finalTransit(final));
        gameObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
