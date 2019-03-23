using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Interact();
    }


    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);

            if (hasHit)
            {
                InfestationObject infestationObject = hit.transform.GetComponent<InfestationObject>();

                if (infestationObject != null)
                {
                    // TODO change infestation based on current weapon
                }
            }
        }
    }
}
