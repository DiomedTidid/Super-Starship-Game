using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private float xBound = 27;
    private float yBound = 37;
    
    
    
    void LateUpdate()
    {
        Vector3 pos = transform.position; 
        if (transform.position.x > xBound) pos.x = xBound;
        if (transform.position.x < -xBound) pos.x = -xBound;
        if (transform.position.y > yBound) pos.y = yBound;
        if (transform.position.y < -yBound) pos.y = -yBound;

        transform.position = pos;
    }
}
