using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDungeons : MonoBehaviour
{
    public GameObject Playerrg;
    public Transform Player;
    public Transform Dungeon01;
    public Transform Dungeon02;
    public Transform Dungeon03;
    public Transform Base;
    public int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Teleport");
    }
    IEnumerator Teleport()
    {
        Playerrg.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        if (count == 0)
        {
            Player.transform.position = Dungeon01.position;
        }
        else if (count == 1)
        {
            Player.transform.position = Dungeon02.position;
        }
        else if (count == 2)
        {
            Player.transform.position = Dungeon03.position;
        }
        else
        {
            Player.transform.position = Base.position;
        }
        yield return new WaitForSeconds(0.1f);
        Playerrg.SetActive(true);
        count++;
    }
}
