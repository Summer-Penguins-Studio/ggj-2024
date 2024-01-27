using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector3 position)
    {
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        transform.position = position;   
        gameObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
