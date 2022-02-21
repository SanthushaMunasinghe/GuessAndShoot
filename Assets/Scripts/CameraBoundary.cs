using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    [SerializeField] SpriteRenderer boundary;

    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = boundary.bounds.size.x / boundary.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = boundary.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = boundary.bounds.size.y / 2 * differenceInSize;
        }
    }
}
