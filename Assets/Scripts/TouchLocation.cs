using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation
{
    public int touchId;
    public GameObject bullet;

    public TouchLocation(int newTouchId)
    {
        touchId = newTouchId;
    }
}
