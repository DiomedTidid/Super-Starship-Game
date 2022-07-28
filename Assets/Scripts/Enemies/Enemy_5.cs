using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy
{
    [Header("Set in Inspector")]
    [SerializeField] private float waveFrequency = 2;
    [SerializeField] private float waveWidth = 4;
    [SerializeField] private float waveRotY = 45;

    private float x0;
    private float birthTime;

    void Start()
    {
        x0 = pos.x;
        birthTime = Time.time;
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        base.Move();
    }
    
}
