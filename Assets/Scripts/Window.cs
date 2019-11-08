using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Abstract;
using TMPro;

//Handler for the 'windows' that pop up when hovering over a tower
public class Window : MonoBehaviour
{

    [SerializeField]
    Button CloseButton;

    [SerializeField]
    TextMeshProUGUI Header;

    [HideInInspector] //Hide it from the inspector since we don't need it to be there. (variable is only set at runtime)
    public Tower connectedTo;

    public bool pinned {
        set {
            _pinned = value;
            if (value) //Show CloseButton when pinned is set to true
                CloseButton.gameObject.SetActive(true);
        }
        get { return _pinned; }
    }
    bool _pinned;

    void Start()
    {
        //Destroy window when CloseButton is clicked. Bit ugly to use a lambda just for this but it works.

        CloseButton.onClick.AddListener(
            () =>
            {
                Destroy(gameObject);
                connectedTo.showingWindow = false;
            }
        );
        
        Header.text = connectedTo.Name;
    }

    void Update()
    {
    }
}
