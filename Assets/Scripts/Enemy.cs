using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip explosionSound;
    public GameObject shoot;
    public GameObject explosionSprite;
    
    public float velocity;

    private float lastShoot;

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.left * velocity * Time.deltaTime;
        
        if (Time.time > lastShoot + 1.0) {
            createShoot();
            lastShoot = Time.time;
        }
    }

    // Private functions
    private void createShoot() {
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        GameObject explosion = Instantiate(explosionSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }
}