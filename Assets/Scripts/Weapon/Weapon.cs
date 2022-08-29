using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private LineRenderer laserBeam;
    [SerializeField] private ParticleSystem laserDamageEffect;
    private float timeSinceLastShoot = 0;
    private float laserDistance = 20f;
    private Enemy enemy;
    

    private void OnEnable()
    {
        if (weaponData.isItLaser)
        {
            Hero.shootAction += Laser;
            Hero.unshootAction += LaserOff;
        } 
       else Hero.shootAction += Shoot;
    }

   

    private void OnDisable()
    {
        if (weaponData.isItLaser)
        {
            Hero.shootAction -= Laser;
            Hero.unshootAction -= LaserOff;
        } 
        else Hero.shootAction -= Shoot;

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

    private void Laser()
    {
        Ray ray = new Ray(muzzle.position, Vector3.up);
        Physics.Raycast(ray,out RaycastHit hit, weaponData.enemyLayer);
        if (hit.distance == 0 || hit.distance > laserDistance)
        { 
            LaserShoot(muzzle.position, new Vector3(muzzle.position.x, muzzle.position.y + laserDistance, muzzle.position.z));
            laserDamageEffect.Pause();
            laserDamageEffect.Clear();
        }
        else
        {
            LaserShoot(muzzle.transform.position, hit.point);
            enemy = hit.collider.GetComponent<Enemy>();
            laserDamageEffect.Play();
            laserDamageEffect.transform.position = hit.point;
            laserDamageEffect.transform.rotation = new Quaternion(0,180,0,0);
            if (enemy != null) enemy.TakeDamage(weaponData.continuousDamage * Time.deltaTime);
            
             
        }
        laserBeam.enabled = true;

    }

    private void LaserShoot (Vector3 startPos, Vector3 endPos)
    {
        laserBeam.SetPosition(0, startPos);
        laserBeam.SetPosition(1, endPos);
    }
    private void LaserOff()
    {
        laserBeam.enabled = false;
        laserDamageEffect.Pause();
        laserDamageEffect.Clear();
    }
}
