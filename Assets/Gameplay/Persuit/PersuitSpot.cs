using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersuitSpot : MonoBehaviour
{
    [SerializeField] private VoidEventChannel m_Event;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Event.RaiseEvent();
        }    
    }
}
