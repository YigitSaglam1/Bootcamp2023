using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    public GameObject WeaponLogic;

    public void LogicOn()
    {
        WeaponLogic.SetActive(true);
    }
    public void LogicOff()
    {
        WeaponLogic.SetActive(false);
    }
}
