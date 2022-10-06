﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [Header("Rotation")]
    
    [Range(0, 360)]
    public float speed = 90;

    
    [Header("Colors")]
    
    public MeshRenderer meshRenderer;
    
    [SerializeField] [Range(0f, 1f)] private float lerpTime;

    [SerializeField] private Color[] lerpColors;

    private int colorIndex = 0;

    private float t = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed, speed, speed);

        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, lerpColors[colorIndex], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= lerpColors.Length) ? 0 : colorIndex;
        }
    }
}