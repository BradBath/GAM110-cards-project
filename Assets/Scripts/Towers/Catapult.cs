using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Abstract;
public class Catapult: Tower
{

    /*ToDo list:
     * Create a menu system for towers.
     * menu system will show stats for towers (damage, firing speed) and upgrading 
     * menus can be pinned (meaning that they will stay in place and can be interacted with) but also have a sort-of preview on hover which will disappear when the mouse stops hovering the object.
    */

    private void Start()
    {
        Name = "Catapult"; //Set the name of the tower so the UI windows display the right name. There might be a better way to do this.
    }

    public override void MouseDown()
    {
        //Pin upgrade menu so you can interact with it
        throw new System.NotImplementedException();
    }

    public override void MouseHoverOff()
    {
        //Shows upgrade menu 
        print("Hovered off.");
    }
    public override void MouseHoverOn()
    {
        //Hides upgrade menu (if not pinned)
        print("Hovered on.");
    }

    public override void MouseUp()
    {
        //Not sure what to put here.
        throw new System.NotImplementedException();
    }
    void Update()
    {
        //Do update code (enemy detection, shooting)
    }
}
