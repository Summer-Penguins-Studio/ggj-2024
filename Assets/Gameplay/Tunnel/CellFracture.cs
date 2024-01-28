using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFracture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Random.Range(0,3));
    }
}
