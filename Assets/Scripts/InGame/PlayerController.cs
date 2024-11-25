using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public Rigidbody2D rb;
    public Gun gun;
    public float shootInterval = 1.5f;
    public int burstCount = 3;
    public float burstDelay = 0.1f;

    Vector2 moveDirection;
    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        //Start automatic shooting
        StartCoroutine(AutoFire());
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    //TODO: Implement auto-shoot (default: burst-fire)
    private IEnumerator AutoFire()
    {
        while(true)
        {
            yield return StartCoroutine(BurstFire());
            yield return new WaitForSeconds(shootInterval);
        }
    }

    private IEnumerator BurstFire()
    {
        for(int i = 0; i < burstCount; i++)
        {
            gun.shootWeapon();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    //Hit detection
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
