using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject stoneFracture;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            Instantiate(stoneFracture, transform.position, Quaternion.identity);
            transform.position = spawnPoint.position;
        }
    }

}
