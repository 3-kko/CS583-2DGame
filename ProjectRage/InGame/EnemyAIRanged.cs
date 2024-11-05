using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Ranged : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public float rotationSpeed = 0.025f;
    private Rigidbody2D rb;

    //Unique variables for ranged enemy
    public float shootingDistance = 5f;
    public float stopDistance = 3f;
    public float fireRate = 2f;
    private float shootInterval; //timetofire
    public Transform firingPoint;
    public GameObject bullet;
    public Gun enemyGun;

    private bool isShooting = false;

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FindPlayer()
    {
        Vector2 playerDirection = target.position - transform.position;
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;

        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private IEnumerator ShootAtPlayer()
    {
        isShooting = true;
        while(true)
        {
            enemyGun.shootWeapon();
            yield return new WaitForSeconds(shootInterval);
        }
        //isShooting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootInterval = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        {
            //get the target
            GetTarget();
        }
        else
        {
            //Move towards the target
            FindPlayer();
        }

        if(Vector2.Distance(target.position, transform.position) <= shootingDistance && !isShooting)
        {
            StartCoroutine(ShootAtPlayer());
        }
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position) >= stopDistance)
        {
            //Move forwards
            rb.velocity = transform.up * moveSpeed;
        }
        else
        {
            rb.velocity *= 0;
        }
    }
}
