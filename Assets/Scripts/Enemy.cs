using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private float health = 10;
    private int score = 100;

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
}
