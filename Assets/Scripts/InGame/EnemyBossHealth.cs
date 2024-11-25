using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBossHealth : MonoBehaviour
{
    //Health segment
    [SerializeField] private float health;
    public float maxHealth;
    public Image healthBar;
    //Spawner segment
    [SerializeField] EnemySpawner[] enemySpawners;
    private bool triggedSpawns = false;
    //Death segment
    [SerializeField] private AudioClip bossDeathSound;
    private AudioSource audioSource;
    public GameObject winScreen;
    private SpriteRenderer[] spriteRenderer;

    public void TakeDamage(float damage)
    {
        health -= damage;

        //Phase 2 trigger: spawn enemies when boss reaches 75% HP
        if(health <= (maxHealth * 0.75) && !triggedSpawns)
        {
            foreach(EnemySpawner spawner in enemySpawners)
            {
                spawner.StartSpawning();
                Debug.Log("Minions Spawning!");
            }
            triggedSpawns = true;
        }

        if(health <= 0f)
        {
            //Transition to victory screen
            BossHasDied();
        }
    }

    private void BossHasDied()
    {
        //play death sound
        if(bossDeathSound != null)
        {
            audioSource.PlayOneShot(bossDeathSound);
        }

        //Disable boss
        foreach (SpriteRenderer sr in spriteRenderer)
        {
            sr.enabled = false;
        }

        //transition to victory screen
        StartCoroutine(BossDeathSequence());
    }

    private IEnumerator BossDeathSequence()
    {
        // Wait briefly for the sound to play
        yield return new WaitForSeconds(1f);

        //"kill" boss
        Destroy(gameObject);
        Debug.Log("Killed Enemy!");

        // Pause the game
        Time.timeScale = 0f;

        // Show win screen
        winScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
