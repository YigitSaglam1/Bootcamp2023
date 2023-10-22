using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform RiffleTip;
    public Transform PlayerTransform;
    private float damageAmount = 10f;
    public ParticleSystem MuzzleFlash;
    public float hitForce = 50f;
    public float WeaponRange = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit hit;
        Ray ray = new Ray(RiffleTip.transform.position, PlayerTransform.transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hit, WeaponRange))
        {
            
            Target target = hit.transform.GetComponent<Target>();
            BoxBreak box = hit.transform.GetComponent<BoxBreak>();
            if (target != null)
            {
                target.TakeDamage(damageAmount);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
            if (box != null)
            {
                box.TakeDamage(damageAmount);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
            else {}
        }

    }
}
