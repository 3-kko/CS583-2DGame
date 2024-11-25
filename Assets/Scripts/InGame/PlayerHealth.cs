using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    public float maxHealth;
    public Image healthBar;
    public GameObject loseScreen;
    private SpriteRenderer[] spriteRenderer;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player took damage");

        if(health <= 0f)
        {
            //Transition to lose screen
            StartCoroutine(PlayerHasDied());
        }
    }

    private IEnumerator PlayerHasDied()
    {
        //Disable boss
        foreach (SpriteRenderer sr in spriteRenderer)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(2f);

        Debug.Log("Player Died!");

        Time.timeScale = 0f;

        //Show Lose Screen
        loseScreen.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //hit collision for generic enemy
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(50);
        }

        //hit collision for boss
        if(collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(100);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
