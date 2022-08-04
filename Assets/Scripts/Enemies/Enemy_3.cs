using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    
    private float lerpSpeed = 0.5f;
    
    public override void Move()
    {
        if (Hero.S != null)
        {
            var nextPosition = Vector3.Lerp(transform.position, Hero.S.transform.position, Time.deltaTime*lerpSpeed);
            nextPosition.y = pos.y;
            transform.position = nextPosition;
        }
        base.Move();
    }

    
}
