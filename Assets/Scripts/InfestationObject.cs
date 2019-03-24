/*
 * Script for managing infestation objects, objects that can "carry" an infestation which can be removed by the player
 * 
 * Handles particle system and infestation level
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfestationObject : MonoBehaviour
{
    [Header("Infestation")]
    [SerializeField] float maxInfestation = 100f;
    [SerializeField] float passiveInfestationDelay = 0.5f;
    [SerializeField] float passiveInfestationAmount = 3f;

    [Header("Infestation visual")]
    [SerializeField] Color cleanColor = Color.cyan;
    [SerializeField] Color infestedColor = Color.red;

    [Header("Bug Particles")]
    [SerializeField] ParticleSystem bugEffectToUse;
    [SerializeField] float maxBugParticles = 50f;

    float currentInfestation = 100;
    float timeSinceLastPassiveInfest = 0;
    Renderer rend;

    ParticleSystem bugEffect;
    ParticleSystem.MainModule bugEffectSettings;
    bool bugEffectPlaying = true;

    int bugCount = 0;

    void Start()
    {
        currentInfestation = maxInfestation;
        rend = GetComponent<Renderer>();
        bugEffect = Instantiate(bugEffectToUse, transform);
        bugEffectSettings = bugEffect.main;
    }

    void Update()
    {
        ManageParticles();
        UpdateBugCount();
        PassiveInfest();
        ColorByInfestation();
    }

    private void PassiveInfest()
    {
        timeSinceLastPassiveInfest += Time.deltaTime;
        if (bugEffectPlaying)
        {
            if (timeSinceLastPassiveInfest >= passiveInfestationDelay)
            {
                AddInfestation(passiveInfestationAmount);
                timeSinceLastPassiveInfest = 0;
            }
        }
    }

    public int GetBugCount()
    {
        return bugCount;
    }

    private void UpdateBugCount()
    {
        if (bugEffect != null)
        {
            bugCount = bugEffect.particleCount;
        }
        else
        {
            bugCount = 0;
        }
    }

    private void ManageParticles()
    {
        if (bugEffectPlaying)
        {
            bugEffectSettings.maxParticles = Mathf.RoundToInt(InfestationPercent() * maxBugParticles);
        }
        
        if (bugEffectPlaying && currentInfestation == 0)
        {
            //bugEffect.Stop();
            Destroy(bugEffect);
            bugEffectPlaying = false;
        }
        
        /* 
        if (!bugEffectPlaying && currentInfestation > 1)
        {
            bugEffect.Play();
            bugEffectPlaying = true;
        }
        */
    }

    public void AddInfestation(float amount)
    {
        currentInfestation = Mathf.Clamp(currentInfestation + amount, 0, maxInfestation);
    }

    public void RemoveInfestation(float amount)
    {
        currentInfestation = Mathf.Clamp(currentInfestation - amount, 0, maxInfestation);
    }

    private void ColorByInfestation()
    {
        rend.material.color = Color.Lerp(cleanColor, infestedColor, InfestationPercent());
    }

    float InfestationPercent()
    {
        return currentInfestation / maxInfestation;
    }
}
