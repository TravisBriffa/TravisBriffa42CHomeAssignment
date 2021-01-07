using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    Material roadBackground;
    Vector2 offset;

    void Start()
    {
        roadBackground = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }


    void Update()
    {
        roadBackground.mainTextureOffset += offset * Time.deltaTime;

    }
}
