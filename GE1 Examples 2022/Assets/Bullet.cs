using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5.0f;

    public float velocity;

    private void Awake()
    {
        StartCoroutine(DeleteMe());
    }

    IEnumerator DeleteMe()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyTank")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Collider col = other.gameObject.GetComponent<BoxCollider>();

            col.isTrigger = true;
            rb.isKinematic = false;
        }
    }
}
