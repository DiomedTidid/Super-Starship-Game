using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon SO", order = 1)]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField]
    public string type { get; private set; }
   
    public GameObject projectilePrefab;
    [field: SerializeField]
    public float damageOnHit { get; private set; }
    [field: SerializeField]
    public float continuousDamage { get; private set; }
    [field: SerializeField]
    public float delayBetweenShots { get; private set; }
    [field: SerializeField]
    public float velocity { get; private set; }

}
