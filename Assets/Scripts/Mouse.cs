using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Abstract;
namespace Game
{
    public class Mouse : MonoBehaviour
    {
        //This script handles mouse interaction with towers (such as hovering and clicking). Should be attached to camera.
        Tower currentlyHovering; //Keep track of what we are currently hovering so we can call MouseHoverOff when we stop hovering it.

        [SerializeField] //This attribute serializes the variable so it can be displayed in the inspector without being a public variable
        Camera mainCamera; // Main camera of the scene (Camera.main is slow)

        [SerializeField]
        GameObject windowPrefab;

        GameObject instantiatedWindow; //Keep track of any instantiated windows.

        void Update()
        {
            DoHover();
            DoClick();
        }

        void DoClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(currentlyHovering!=null && instantiatedWindow != null)
                {
                    instantiatedWindow.GetComponent<Window>().pinned = true;
                    instantiatedWindow = null; //Set instantiatedWindow to null when it's pinned. It can now only be closed when clicking on the windows close button.
                    currentlyHovering.showingWindow = true;
                }
            }
        }

        void DoHover()
        {
            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit))
            {
                //I just realized that this pretty much makes the MouseHover, and ectera, functions inside Tower.cs redundant. Refactor, maybe?
                if (hit.transform && hit.transform.GetComponent<Tower>())
                {
                    Tower towerController = hit.transform.GetComponent<Tower>();
                    if (towerController == currentlyHovering || towerController.showingWindow)
                        return;

                    towerController.MouseHoverOn();

                    GameObject window = Instantiate<GameObject>(windowPrefab, towerController.transform.position + Vector3.up * 2, Quaternion.identity);
                    if (currentlyHovering)
                        currentlyHovering.MouseHoverOff();
                    if (instantiatedWindow != null)
                        Destroy(instantiatedWindow);
                    instantiatedWindow = window;
                    window.GetComponent<Window>().connectedTo = towerController;
                    currentlyHovering = towerController;
                }
                else if (!hit.transform || !hit.transform.GetComponent<Tower>())
                {

                    currentlyHovering.MouseHoverOff();
                    currentlyHovering = null;
                    if (instantiatedWindow != null)
                        Destroy(instantiatedWindow);
                }
            }
            else
            {
                if (currentlyHovering)
                {
                    currentlyHovering.MouseHoverOff();
                    currentlyHovering = null;
                    if (instantiatedWindow != null)
                        Destroy(instantiatedWindow);
                }
            }
        }

    }
}
