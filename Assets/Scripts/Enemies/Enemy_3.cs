using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    private Transform heroPos;
    private float lerpSpeed = 0.5f;
    private void Start()
    {
        heroPos = GameObject.Find("Hero").GetComponent<Transform>();
    }


    public override void Move()
    {
        if (heroPos != null)
        {
            var nextPosition = Vector3.Lerp(transform.position, heroPos.transform.position, Time.deltaTime*lerpSpeed);
            nextPosition.y = pos.y;
            transform.position = nextPosition;
        }
        base.Move();
    }

    
}
