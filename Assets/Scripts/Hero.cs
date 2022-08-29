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
    [SerializeField]  private float pitchMult = 30;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shield;
    [SerializeField] private TextMeshProUGUI shieldLevelText;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private ParticleSystem engineFireMain;
    [SerializeField] private ParticleSystem engineFireRight;
    [SerializeField] private ParticleSystem engineFireLeft;
    [SerializeField] private ParticleSystem[] noseFires;
    public static event Action shootAction;
    public static event Action unshootAction;


    private float restartDelay = 3f;
    private float xAxis;
    private float yAxis;
    [Header("Set Dynamically")]
    public float shieldLevel = 1;
    void Awake()
    {
        if (S == null) S = this;
        else Debug.LogError("Hero.Awake() - second Hero");
        
    }

   
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        Move();
        EngineFire();

        if (Input.GetAxis("Jump") == 1) shootAction?.Invoke();
        if (Input.GetKeyUp(KeyCode.Space)) unshootAction?.Invoke();
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) AbsorbPowerUp(other);
        else
        {
            ShieldLevelDown();
            Destroy(other.gameObject);
        }
        
    }

    private void AbsorbPowerUp(Collider other)
    {
        PowerUp pu = other.GetComponent<PowerUp>();
        switch (pu.type)

        {
            case "Blaster":
                BlasterActivate();
                break;
            case "Shield":
                ShieldLevelUp();
                break;
            case "Laser":
                DeactivateAllGuns();
                weapons[3].SetActive(true);
                break;
            default: return;
        }
    }

    

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * pitchMult, 0);
        
    }

    private void EngineFire()
    {
        if (yAxis > 0.1) engineFireMain.Play();
        else 
        {
            engineFireMain.Pause();
            engineFireMain.Clear();
        }
        if (yAxis < -0.1) foreach (var item in noseFires) item.Play();
        else
        {
            foreach (var item in noseFires)
            {
                item.Pause();
                item.Clear();
            }
        }
               
        if (xAxis > 0) engineFireLeft.Play();
        else
        {
            engineFireLeft.Pause();
            engineFireLeft.Clear();
        }
        if (xAxis < 0) engineFireRight.Play();
        else
        {
            engineFireRight.Pause();
            engineFireRight.Clear();
        }
       
    }
    private void ShieldLevelDown ()
    {
        shieldLevel--;
        shieldLevelText.text = "Shield Level: " + shieldLevel;
        if(shieldLevel < 0)
        {
            Destroy(this.gameObject);
            shieldLevelText.text = "Shield Level: " + (shieldLevel+1);
            GlobalEventManager.OnGameOver.Invoke();
                       
        }
        else if (shieldLevel == 0) shield.SetActive(false);
    }

    private void ShieldLevelUp()
    {
        shieldLevel++;
        if (shieldLevel == 1) shield.SetActive(true);
        shieldLevelText.text = "Shield Level: " + shieldLevel;
    }
    private void BlasterActivate()
    {
        if (!weapons[0].activeInHierarchy)
        {
            DeactivateAllGuns();
            weapons[0].SetActive(true);
        }
        else if (!weapons[1].activeInHierarchy) weapons[1].SetActive(true);
        else weapons[2].SetActive(true);
    }
    private void DeactivateAllGuns()
    {
        foreach (var item in weapons)
        {
            item.SetActive(false);
        }
    }
}
