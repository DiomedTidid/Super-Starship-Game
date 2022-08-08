using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private float rotation = 15;
    [field : SerializeField] public string type { get; private set; }

   
    private Vector3 pos { get => transform.position; set { transform.position = value; } }
    private void Update()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
        transform.rotation = Quaternion.Euler(0,rotation* Time.time, rotation*Time.time);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
