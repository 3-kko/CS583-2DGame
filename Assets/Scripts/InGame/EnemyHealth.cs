using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    public float maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Killed Enemy!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
