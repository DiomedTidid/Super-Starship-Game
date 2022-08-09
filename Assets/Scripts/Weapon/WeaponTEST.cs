using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTEST : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponData;
    [SerializeField] private Transform muzzle;
    private float timeSinceLastShoot = 0;

    private void OnEnable()
    {
       Hero.shootAction += Shoot;
    }

    private void OnDisable()
    {
        Hero.shootAction -= Shoot;
       
    }

    void Update()
    {
        timeSinceLastShoot += Time.deltaTime;
    }

    public void Shoot()
    {
        if (timeSinceLastShoot < weaponData.delayBetweenShots) return;
        GameObject projGo = Instantiate(weaponData.projectilePrefab);
        projGo.transform.position = muzzle.position;
        Rigidbody rigidB = projGo.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * weaponData.velocity;
        timeSinceLastShoot = 0;

    }

    
}
