using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy
{
    [Header("Set in Inspector")]
    [SerializeField] private float amplitude = 8;
    [SerializeField] private float frequency = 1.5f;

    private float x0;
    private float sin0 = 20;
   

    void Start()
    {
        if (pos.x < -sin0) x0 = -sin0;
        else if (pos.x > sin0) x0 = sin0;
        else x0 = pos.x;
        
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        float sin = Mathf.Sin(Time.time*frequency)*amplitude;
        tempPos.x = x0 + sin;
        pos = tempPos;

        base.Move();
    }
    
}
