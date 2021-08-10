using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Pistol : Weapon
{
    void Start()
    {
        damage = 5f;
        range = 100f;
        fireRate = 1.5f;
        firingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
}
