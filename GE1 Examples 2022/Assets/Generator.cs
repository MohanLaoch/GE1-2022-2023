using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //public int loops = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        /*for (var i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }*/

        Vector3 targetPosition = Vector3.zero;
        
        for (var i = 0; i < 10; i++)
        {
            GameObject instance = Instantiate(prefab);

            float angle = i * (2 * 3.14f / 10);

            float x = Mathf.Cos(angle) * 1.5f;
            float y = Mathf.Sin(angle) * 1.5f;

            targetPosition = new Vector3(targetPosition.x + x, targetPosition.y + y, 0);

            instance.transform.position = targetPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
