using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip deadByEnemy;
    [SerializeField] private AudioClip deadByCar;
    [SerializeField] private AudioSource source;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }

    public void PlayDeadByEnemy()
    {
        source.clip = deadByEnemy;
        source.Play();
    }

    public void PlayDeadByCar()
    {
        source.clip = deadByCar;
        source.Play();
    }
}
