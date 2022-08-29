using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private float health = 1;
    [SerializeField] private int score = 100;
    [SerializeField] private ParticleSystem spark;

    public Vector3 pos { get => transform.position; set { transform.position = value; } }


    void Update()
    {
        Move();
    }

   public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.tag == "ProjectileHero")
        {
            TakeDamage(otherGO.GetComponent<Projectile>().weaponData.damageOnHit);
            Destroy(otherGO);
            
            
        }
        else Debug.Log("Enemy hit by non-ProjectileHero");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GlobalEventManager.SendEnemyKilled(transform.position, score);
            Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }



}
