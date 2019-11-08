using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Abstract
{
    //Base class for towers. All tower types should inherit from this. This is the strategy design pattern.
    public abstract class Tower : MonoBehaviour
    {
        public abstract void MouseDown();
        public abstract void MouseHoverOff();
        public abstract void MouseHoverOn();
        public abstract void MouseUp();
    }
}
