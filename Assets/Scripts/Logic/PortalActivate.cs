using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivate : MonoBehaviour
{
    public ParticleSystem Portal01;
    public ParticleSystem Portal02;
    public GameObject Teleport;
    private void Start()
    {
        Teleport.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Portal01.Play();
        Portal02.Play();
        Teleport.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Portal01.Stop();
        Portal02.Stop();
        Teleport.SetActive(false);
    }
}
