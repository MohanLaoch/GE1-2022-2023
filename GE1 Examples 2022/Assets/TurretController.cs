using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;
    public float range;

    public float rotateSpeed;

    public string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        CapsuleCollider detect = GetComponent<CapsuleCollider>();
        detect.radius = range * 2;
    }

    public void OnTriggerStay(Collider other)
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearPlayer = null;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < shortestDistance)
        {
            shortestDistance = distanceToPlayer;
            nearPlayer = player;
        }

        if (nearPlayer != null && shortestDistance <= range)
        {
            target = nearPlayer.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        this.transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
