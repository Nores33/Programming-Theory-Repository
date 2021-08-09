using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMachineGun : Weapon
{
    void Start()
    {
        damage = 3f;
        range = 100f;
        fireRate = 10f;
        firingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
}
