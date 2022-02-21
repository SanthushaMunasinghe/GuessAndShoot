using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRaycast : MonoBehaviour
{
    [SerializeField] private TargetSpawnManager targetSpawnManager;

    [SerializeField] private Text directionTxt;

    [SerializeField] private AudioSource left;
    [SerializeField] private AudioSource right;
    [SerializeField] private AudioSource up;
    [SerializeField] private AudioSource down;

    public void TouchRay(Touch t)
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, t.position);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Target")
            {
                targetSpawnManager.DestroyTarget();
            }
            else
            {
                Vector2 colPos = hit.collider.gameObject.transform.position;
                if (colPos.x == targetSpawnManager.spawnedTargetPos.x)
                {
                    //Debug.Log("f");
                    if (colPos.y < targetSpawnManager.spawnedTargetPos.y)
                    {
                        //Debug.Log("Up");
                        directionTxt.text = "Up";
                        up.Play();
                    }
                    else if (colPos.y > targetSpawnManager.spawnedTargetPos.y)
                    {
                        //Debug.Log("Down");
                        directionTxt.text = "Down";
                        down.Play();
                    }
                }
                else
                {
                    if (colPos.x < targetSpawnManager.spawnedTargetPos.x)
                    {
                        //Debug.Log("Right");
                        directionTxt.text = "Right";
                        right.Play();
                    }
                    else if (colPos.x > targetSpawnManager.spawnedTargetPos.x)
                    {
                        //Debug.Log("Left");
                        directionTxt.text = "Left";
                        left.Play();
                    }
                }
            }
        }
    }
}
