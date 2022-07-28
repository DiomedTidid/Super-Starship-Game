using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundsCheck : MonoBehaviour
{
    private float xBound = 35;
    private float yBound = 47;



    void LateUpdate()
    {

        if (transform.position.x > xBound) Destroy(gameObject);
        if (transform.position.x < -xBound) Destroy(gameObject);
        if (transform.position.y < -yBound) Destroy(gameObject);
        if (transform.position.y > yBound) Destroy(gameObject);

    }
}
