using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponObject : ScriptableObject
{
    public string weaponName;
    public float weaponDamage;
    public float timeBetweenAttack;

    public ParticleSystem weaponEffect;

    // TODO add artwork field for UI
    // TODO add sound effect field 
}
