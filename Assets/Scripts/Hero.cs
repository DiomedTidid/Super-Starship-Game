using System.Collections;
using System.Collections.Generic;
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

    private float restartDelay = 3f;

    [Header("Set Dynamically")]
    public float shieldLevel = 1;
    void Awake()
    {
        if (S == null) S = this;
        else Debug.LogError("Hero.Awake() - second Hero");
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

        if (Input.GetKeyDown(KeyCode.Space)) TempFire();

    }

    private void OnTriggerEnter(Collider other)
    {
        shieldLevel--;
        Destroy(other.gameObject);
        if (shieldLevel < 0)
        {
            Destroy(this.gameObject);
            EnemySpawner.S.DelayedRestart(restartDelay);
        }
        else if (shieldLevel == 0)  shield.SetActive(false);     
    }

    private void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(bulletPrefab);
        projGo.transform.position = transform.position;
        Rigidbody rigidB = projGo.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * bulletSpeed; 
    }

}
