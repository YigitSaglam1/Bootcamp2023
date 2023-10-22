using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{
    private Vector3 end;

    private Vector3 dampingVelocity;
    private Vector3 impact;
    private float verticalVelocty;
    public Vector3 Movement => impact + Vector3.up * verticalVelocty;
    
    private void Update()
    {
        if (end.y >= transform.position.y)
        {
            Vector3 pos = transform.position;
            pos.y = end.y;
            transform.position = pos;
            verticalVelocty = 0f;
        }
        else
        {
            verticalVelocty += Time.deltaTime * Physics.gravity.y;
        }
        
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, 1f);

        if (impact.sqrMagnitude < 0.2f * 0.2f)
        {
            impact = Vector3.zero;
        }

        transform.Translate(Movement * Time.deltaTime);
    }

    public void AddForce(Vector3 force, Vector3 end)
    {
        impact += force;
        this.end = end;
    }
}
