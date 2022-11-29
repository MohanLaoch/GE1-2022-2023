using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject cubePrefab;

    public int height = 5;
    public float radius = 5f;
    public int numberOfCubes = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tower();
        }
    }

    void Tower()
    {
        for (int j = 0; j < height; j++)
        {

            for (int i = 0; i < numberOfCubes; i++)
            {
                float angle = i * Mathf.PI * 2 / numberOfCubes;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;

                Vector3 pos = transform.position + new Vector3(x, j, z);

                float angleDegrees = angle * Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);

                Instantiate(cubePrefab, pos, rot);

                //cubePrefab.GetComponent<Renderer>().material.color = Color.HSVToRGB(i * j / (float)(numberOfCubes * height), 1.0f, 1.0f);
            }
        }
    }

}
