using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 targetPosition = Vector3.zero;
        
        for (var j = 0; j < loops; j++)
        {
            float radius = 2f * j;

            int circumference = (int) (2 * Mathf.PI * radius);

            for (var i = 0; i < circumference; i++)
            {
                float cx = transform.position.x;
                float cy = transform.position.y;

                float angle = (2 * Mathf.PI / circumference) * i;
                
                float x = cx + radius * Mathf.Cos(angle);
                float y = cy + radius * Mathf.Sin(angle);
                
                GameObject instance = Instantiate(prefab);

                instance.transform.position = new Vector3(x, y, 0);

                //targetPosition = new Vector3(targetPosition.x + x, targetPosition.y + y, 0);

                //instance.transform.position = targetPosition;
            }
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
