using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        //the values for x and y are negative because the coordinates are opposite of world coordinates
        screenBounds = Camera.main.ScreenToWorldPoint[new Vector3](screenBounds.width, screenBounds.height, Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = trasform.position;
        viewPos.x = Mathf.Clamp(viewPos.x,screenBounds.x,screenBounds.x *-1)
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1)


    }
}
