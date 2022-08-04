using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class Hero : MonoBehaviour
{
    static public Hero S;
    [Header("Set in Inspector")]
    [SerializeField]  private float speed = 30;
    [SerializeField]  private float rollMult = -45;
    [SerializeField]  private float pitchMult = 30;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 40;
    [SerializeField] private GameObject shield;
    [SerializeField] private TextMeshProUGUI shieldLevelText;

    public static Action shootAction;
       
    private float restartDelay = 3f;

    [Header("Set Dynamically")]
    public float shieldLevel = 1;
    void Awake()
    {
        if (S == null) S = this;
        else Debug.LogError("Hero.Awake() - second Hero");
        //shoot += TempFire;
    }

    
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * pitchMult, 0);

        //if (Input.GetKeyDown(KeyCode.Space)) TempFire();
        if (Input.GetAxis("Jump") == 1) shootAction?.Invoke();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ShieldLevelDown();
        Destroy(other.gameObject);
        
    }

    private void ShieldLevelDown ()
    {
        shieldLevel--;
        shieldLevelText.text = "Shield Level: " + shieldLevel;
        if(shieldLevel < 0)
        {
            Destroy(this.gameObject);
            shieldLevelText.text = "Shield Level: " + (shieldLevel+1);
            EnemySpawner.S.DelayedRestart(restartDelay);
            shootAction -= TempFire;
        }
        else if (shieldLevel == 0) shield.SetActive(false);
    }

    private void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(bulletPrefab);
        projGo.transform.position = transform.position;
        Rigidbody rigidB = projGo.GetComponent<Rigidbody>();
        //rigidB.velocity = Vector3.up * bulletSpeed;

        Projectile proj = projGo.GetComponent<Projectile>();
        proj.type = WeaponType.blaster;
        float tSpeed = EnemySpawner.GetWeaponDefinition(proj.type).velocity;
        rigidB.velocity = Vector3.up * tSpeed;

    }

}
