using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    [SerializeField] private TouchRaycast touchRaycast;
    [SerializeField] private MainScript mainScript;

    //List to store touches
    public List<TouchLocation> touches = new List<TouchLocation>();

    void Update()
    {
        int i = 0;

        //Calculating touches
        while (i < Input.touchCount)
        {
            //Getting touch and store its' values to t
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)//when finger down
            {
                touches.Add(new TouchLocation(t.fingerId));
                if (t.fingerId == 0 && !mainScript.isGameOver)
                {
                    touchRaycast.TouchRay(t);
                }
            }

            i++;
        }
    }
}
