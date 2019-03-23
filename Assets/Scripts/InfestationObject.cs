using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfestationObject : MonoBehaviour
{
    [SerializeField] float maxInfestation = 100f;

    [SerializeField] Color cleanColor;
    [SerializeField] Color infestedColor;

    float currentInfestation = 0;

    Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        ColorByInfestation();
        // TODO spawn bug particles based on infestation
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
