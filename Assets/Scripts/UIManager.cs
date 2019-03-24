/*
 * Script for managing UI elements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI[] textElements;
    InfestationObject[] infestationObjects;

    Image cursor;

    TextMeshProUGUI bugCountText;
    int bugCount = 0;

    private void Start()
    {
        GetTextElements();
        GetInfestationObjects();

        Cursor.visible = false;
        cursor = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        CountBugs();
        TrackCursor();
    }

    private void TrackCursor()
    {
        cursor.transform.position = Input.mousePosition;
    }

    private void GetTextElements()
    {
        textElements = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in textElements)
        {
            if (text.name == "BugCount")
            {
                bugCountText = text;
            }
        }
    }

    private void GetInfestationObjects()
    {
        infestationObjects = FindObjectsOfType<InfestationObject>();
    }

    private void CountBugs()
    {
        bugCount = 0;
        foreach (InfestationObject infestation in infestationObjects)
        {
            bugCount += infestation.GetBugCount();
        }
        bugCountText.text = bugCount.ToString();
    }
}
