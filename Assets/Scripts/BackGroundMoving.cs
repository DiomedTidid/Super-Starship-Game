using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
    public Vector3 pos { get => transform.position; set { transform.position = value; } }
    private float speed = 3;
    private Vector3 startPosition = new Vector3(0,120,72);
    private float endOfBackground = -180;
    
    void LateUpdate()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
        if (transform.position.y <= endOfBackground) transform.position = startPosition;
    }
    


    
}
