using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public List<Target> Enemies;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(45,20,45));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>() != null)
        {
            Enemies.Add(other.GetComponent<Target>());
            other.GetComponent<Target>().dieEvent += OnDieEvent;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemies.Remove(other.GetComponent<Target>());
    }
    private void OnDieEvent(Target target)
    {
        Enemies.Remove(target.GetComponent<Target>());
        target.dieEvent -= OnDieEvent;
    }
}
