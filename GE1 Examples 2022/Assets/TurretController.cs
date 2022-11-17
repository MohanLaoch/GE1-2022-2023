using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;

    public float range;
    public float rotateSpeed;

    public float fireRate;

    public string playerTag = "Player";

    public GameObject turretBullet;
    public Transform firePoint;

    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        SphereCollider detect = GetComponent<SphereCollider>();
        detect.radius = range / 2;
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
            if (canFire)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            target = null;
        }
    }

    IEnumerator Shoot()
    {
        canFire = false;
        float timeToNextShot = 1 / fireRate;
        Instantiate(turretBullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(timeToNextShot);
        canFire = true;
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
