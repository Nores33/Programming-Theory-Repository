using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float p_Damage;
    private float p_Range;
    private float p_FireRate;

    protected float damage
    {
        get { return p_Damage; }
        set { p_Damage = value; }
    }
    protected float range
    {
        get { return p_Range; }
        set { p_Range = value; }
    }
    protected float fireRate
    {
        get { return p_FireRate; }
        set { p_FireRate = value; }
    }
    protected AudioSource firingSound;
    protected float nextTimeToFire = 0f;

    [SerializeField] protected Camera gunCam;
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected GameObject impactEffect;
    [SerializeField] protected GameObject bulletHole;

    protected virtual void Shoot()
    {
        firingSound.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(gunCam.transform.position, gunCam.transform.forward, out hit, range))
        {
            GameObject impactParticle = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject impactHole = Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            Destroy(impactParticle, 2f);
            Destroy(impactHole, 2f);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
