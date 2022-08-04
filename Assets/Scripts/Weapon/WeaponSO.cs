using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon SO", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string type;
    public WeaponDefinition def;
    public GameObject projectilePrefab;
    public float lastShotTime;
    public float damageOnHit = 0;
    public float continuousDamage = 0;
    public float delayBetweenShots = 0;
    public float velocity = 20;

}
