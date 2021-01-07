using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    void Start()
    {
        
    }


    void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main; // fetching the main camera
        float padding = 0.5f;

        /* ViewportToWorldPoint checks the camera's view at runtime and calculates
         * the actual coordinates but in our code we just refer to the minimum as
         * 0 and maximum as 1.
         * Thus, the code will always be camera size independent.
         */

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
