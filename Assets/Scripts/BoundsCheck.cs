using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [System.Flags]
    public enum eScreenLocs
    {
        onScreen = 0,
        offRight = 1,
        offLeft = 2,
        offUp = 4,
        offDown = 8
    }
    public enum eType { center, inset, outset}
    [Header("Inscribed")]
    public eScreenLocs screenlocs = eScreenLocs.onScreen;
    public eType boundsType = eType.center;
    public float radius = 1f;
    public bool keepOnScreen = true;


    [Header("Dynamic")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;


    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;

        Vector3 pos = transform.position;
        isOnScreen = true;
        //Restrict X position
        if (pos.x > camWidth + checkRadius)
        {
            pos.x = camWidth + checkRadius;
            isOnScreen = false;
        }
        if (pos.x < -camWidth - checkRadius)
        {
            pos.x = -camWidth - checkRadius;
            isOnScreen = false;
        }
        //Restrict Y position
        if (pos.y > camHeight + checkRadius)
        {
            pos.y = camHeight + checkRadius;
            isOnScreen = false;
        }
        if (pos.y < -camHeight - checkRadius)
        {
            pos.y = -camHeight - checkRadius;
            isOnScreen = false;
        }

        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }
    }

}
