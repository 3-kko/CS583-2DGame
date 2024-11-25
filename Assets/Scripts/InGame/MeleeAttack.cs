using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;
    float meleeCooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meleeCooldownTime -= Time.deltaTime;

        if(meleeCooldownTime <= 0f)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                meleeCooldownTime = meleeSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("Melee hit!");
        }

        if(other.tag == "Boss")
        {
            other.GetComponent<EnemyBossHealth>().TakeDamage(damage);
            Debug.Log("Melee hit!");
        }
    }

}
