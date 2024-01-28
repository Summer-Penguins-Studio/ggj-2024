using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpot : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] private bool m_IsPlayed;
    [SerializeField] private float m_Delay;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(m_Delay);
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!m_IsPlayed && other.CompareTag("Player"))
        {
            StartCoroutine(Play());
        }
    }
}
