using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float spread = 5f;
    private int pellets = 5;

    void Start()
    {
        damage = 10f;
        range = 20f;
        fireRate = .5f;
        firingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    protected override void Shoot()
    {
        firingSound.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        for(int i=0; i<pellets; i++)
        {
            Vector3 noAngle = gunCam.transform.forward;
            var Spread = Random.Range(-spread, spread);
            Quaternion spreadAngle = Quaternion.AngleAxis(Spread, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
            Vector3 newVector = spreadAngle * noAngle;

            if (Physics.Raycast(gunCam.transform.position, newVector, out hit, range))
            {
                GameObject impactParticle = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                GameObject impactHole = Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                Destroy(impactParticle, 2f);
                Destroy(impactHole, 2f);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
