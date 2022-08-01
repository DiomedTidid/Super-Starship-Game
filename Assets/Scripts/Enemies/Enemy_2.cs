using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_2 : Enemy
{
    [SerializeField] private float speedX = 10;
    private int moveRigth;
    private float xBound = 27;
    
    void Start()
    {
        moveRigth = Random.Range(0, 1);
        if (moveRigth == 0) moveRigth = -1;

    }

    public override void Move()
    {
        
        Vector3 tempPos = pos;
        tempPos.x += speedX * Time.deltaTime*moveRigth;
        if (tempPos.x >= xBound) moveRigth = -1;
        else if (tempPos.x <= -xBound) moveRigth = 1;
        pos = tempPos;

        base.Move();
    }
}
