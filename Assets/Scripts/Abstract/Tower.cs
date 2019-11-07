using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Abstract
{
    //Base class for towers. All tower types should inherit from this. This is the strategy design pattern.
    public abstract class Tower : MonoBehaviour
    {

        //An abstract function means that whatever inherits from this class MUST implement this function via public override void OnPlacement.
        //This function is also just a test. We need to figure out what functions each tower should have (shoot, placement, mouse down, mouse hover, mouse up, etc)
        public abstract void OnPlacement();
    }
}
