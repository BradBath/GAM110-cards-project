using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Abstract;
public class Mouse : MonoBehaviour
{
    //This script handles mouse interaction with towers (such as hovering and clicking). Should be attached to camera.
    Tower currentlyHovering; //Keep track of what we are currently hovering so we can call MouseHoverOff when we stop hovering it.
    [SerializeField] //This serialized the variable so it can be displayed in the inspector without being a public variable
    Camera mainCamera; // Main camera of the scene (Camera.main is slow)
    void Update()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit))
        {
            if (hit.transform && hit.transform.GetComponent<Tower>())
            {
                Tower towerController = hit.transform.GetComponent<Tower>();
                if (towerController == currentlyHovering)
                    return;

                towerController.MouseHoverOn();
                if (currentlyHovering)
                {
                    currentlyHovering.MouseHoverOff();
                }
                currentlyHovering = towerController;
            }
            else if (!hit.transform || !hit.transform.GetComponent<Tower>())
            {
                currentlyHovering.MouseHoverOff();
                currentlyHovering = null;
            }
        }
        else
        {
            if (currentlyHovering)
            {
                currentlyHovering.MouseHoverOff();
                currentlyHovering = null;
            }
        }
    }
}
