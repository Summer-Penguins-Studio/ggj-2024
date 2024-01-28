using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]GameObject m_gameObject;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position=m_gameObject.transform.position;
    }
}
