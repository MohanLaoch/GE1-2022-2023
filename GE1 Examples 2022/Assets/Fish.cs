using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform head;
    public Transform tail;

    [Range(0.0f, 5f)]
    public float frequency = 0.5f;

    public float headAmplitude = 40;
    public float tailAmplitude = 60;

    public float theta;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        theta = theta + 0.1f;

        head.transform.localRotation = Quaternion.AngleAxis(headAmplitude * Mathf.Sin(theta * frequency), Vector3.forward);
        tail.transform.localRotation = Quaternion.AngleAxis(tailAmplitude * Mathf.Sin(theta * frequency), Vector3.forward);
    }
    /*
     * Mathf.Sin
     * Quaternion.AngleAxis
     * transform.localRotation
     */
}
