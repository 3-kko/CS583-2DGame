using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet detection for generic enemy
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Enemy shot!");
                Destroy(gameObject); // Destroy bullet on impact
            }
        }

        //Bullet detection for boss
        if (other.CompareTag("Boss"))
        {
            EnemyBossHealth enemyBossHealth = other.GetComponent<EnemyBossHealth>();
            if (enemyBossHealth != null)
            {
                enemyBossHealth.TakeDamage(damage);
                Debug.Log("Boss shot!");
                Destroy(gameObject); // Destroy bullet on impact
            }
        }

        //bullet detection for player
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Player shot!");
                Destroy(gameObject); // Destroy bullet on impact
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f); // Destroy after 5 seconds if it doesn’t hit anything
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
