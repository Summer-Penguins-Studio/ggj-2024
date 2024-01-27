using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrounch : MonoBehaviour
{
    [SerializeField] private Transform m_PlayerBody;
    [SerializeField] private bool m_IsCrounched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") >= 0.5f)
        {
            m_PlayerBody.transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            m_PlayerBody.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
