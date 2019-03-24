/*
 * Script for managing the bugZone on an infestationObject (where the bug particles
 * are contained)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugZone : MonoBehaviour
{
    public void setBugZoneScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
