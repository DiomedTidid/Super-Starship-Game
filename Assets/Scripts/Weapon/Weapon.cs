using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    none,
    blaster,
    spread,
    phaser,
    missile,
    laser,
    shield
}
[System.Serializable]
public class WeaponDefinition
{
    public WeaponType type = WeaponType.none;
    public string letter;
    public GameObject projectilePrefab;
    public float damageOnHit = 0;
    public float continuousDamage = 0;
    public float delayBetweenShots = 0;
    public float velocity = 20;

}
public class Weapon : MonoBehaviour
{

}