using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/Car Data"))]
public class CarData : ScriptableObject
{
    [SerializeField] public float Speed;
}
