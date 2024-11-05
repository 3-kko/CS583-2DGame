using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletExitPoint;
    public float bulletVelocity = 20f;
    public float bulletDamage = 25f;
    public AudioClip shootSound;  
    private AudioSource audioSource;

    public void shootWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletExitPoint.position, bulletExitPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletExitPoint.up * bulletVelocity, ForceMode2D.Impulse);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = bulletDamage;
        }

        //play shootSound
        if(shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
