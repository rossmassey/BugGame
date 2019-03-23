using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] WeaponObject currentWeapon;

    bool weaponEffectActive = false;
    ParticleSystem weaponEffect = null;

    float timeSinceLastAttack = 0;

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        Interact();
    }


    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void Interact()
    {
        bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);

        if (hasHit == false)
        {
            return;
        }

        ManageHit(hit);
    }

    private void ManageHit(RaycastHit hit)
    {
        if (currentWeapon != null)
        {
            SpawnWeaponEffect(hit.point);

            InfestationObject infestationObject = hit.transform.GetComponent<InfestationObject>();
            if (infestationObject != null)
            {
                DamageInfestationObject(infestationObject);
            }
        }
    }

    private void DamageInfestationObject(InfestationObject infestationObject)
    {
        if (Input.GetMouseButton(0))
        {
            // have hit infestation object
            if (timeSinceLastAttack >= currentWeapon.timeBetweenAttack)
            {
                infestationObject.RemoveInfestation(currentWeapon.weaponDamage);
                timeSinceLastAttack = 0;
            }
        }
    }

    private void SpawnWeaponEffect(Vector3 position)
    {
        if (Input.GetMouseButton(0)) // left mouse button
        {
            if (weaponEffectActive == false)
            {
                weaponEffect = Instantiate(currentWeapon.weaponEffect, position, Quaternion.identity) as ParticleSystem;
                weaponEffect.Play();
                weaponEffectActive = true;
            }
            else
            {
                weaponEffect.transform.position = position; // particle system will track mouse position if already playing
            }
        }
        else
        {
            if (weaponEffectActive)
            {
                Destroy(weaponEffect.transform.gameObject);
                weaponEffectActive = false;
            }
        }
    }
}
