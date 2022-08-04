using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] public WeaponType type;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    
}
