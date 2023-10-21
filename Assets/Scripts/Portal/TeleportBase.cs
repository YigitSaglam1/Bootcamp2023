using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBase : MonoBehaviour
{
    public GameObject Playerrg;
    public Transform Player;
    public Transform Base;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Teleport");
    }
    IEnumerator Teleport()
    {
        Playerrg.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Player.transform.position = Base.position;
        yield return new WaitForSeconds(0.1f);
        Playerrg.SetActive(true);

    }
}
