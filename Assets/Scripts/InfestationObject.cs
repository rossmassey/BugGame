using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfestationObject : MonoBehaviour
{
    [Header("Infestation")]
    [SerializeField] float maxInfestation = 100f;
    [SerializeField] Color cleanColor;
    [SerializeField] Color infestedColor;

    [Header("Bug Particles")]
    [SerializeField] ParticleSystem bugEffectToUse;
    [SerializeField] float maxBugParticles = 50f;
    // TODO make bugs bounce more

    float currentInfestation = 100;
    Renderer rend;

    ParticleSystem bugEffect;
    ParticleSystem.MainModule bugEffectSettings;
    bool bugEffectPlaying = true;


    void Start()
    {
        rend = GetComponent<Renderer>();
        bugEffect = Instantiate(bugEffectToUse, transform);
        bugEffectSettings = bugEffect.main;
    }

    void Update()
    {
        ColorByInfestation();
        ManageParticles();
    }

    private void ManageParticles()
    {
        if (bugEffectPlaying)
        {
            bugEffectSettings.maxParticles = Mathf.RoundToInt(InfestationPercent() * maxBugParticles);
        }
        
        if (bugEffectPlaying && currentInfestation == 0)
        {
            // TODO figure out why some bugs are left over
            bugEffect.Stop();
            bugEffectPlaying = false;
        }
        
        if (!bugEffectPlaying && currentInfestation > 1)
        {
            bugEffect.Play();
            bugEffectPlaying = true;
        }
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
