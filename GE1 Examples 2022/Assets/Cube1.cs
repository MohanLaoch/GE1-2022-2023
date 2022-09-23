using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1);
        
        Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
        
        GetComponent<Renderer>().material.color = newColor;
    }
}
