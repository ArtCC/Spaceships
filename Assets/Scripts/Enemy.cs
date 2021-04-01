using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip explosionSound;
    public GameObject shoot;
    public GameObject explosionSprite;
    
    public float velocity;

    private Player player;
    private float lastShoot;

    // Start is called before the first frame update
    void Start() {      
        getPlayer();
    }

    // Update is called once per frame
    void Update() {
        if (player != null) {
            var distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > 5) {
                transform.position += Vector3.left * velocity * Time.deltaTime;
            } else if (distance < 4) {
                transform.position += Vector3.right * velocity * Time.deltaTime;
            } else {
                Vector3 offset = player.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, offset);
                transform.rotation = rotation * Quaternion.Euler(0, 0, -90);
            }
        }

        if (Time.time > lastShoot + 1.0) {
            createShoot();
            lastShoot = Time.time;
        }

        autoDestroyForPosition();
    }

    // Private functions
    private void getPlayer() {
        if (FindObjectOfType<Player>() != null) {
            player = FindObjectOfType<Player>();
        }
    }

    private void createShoot() {
    }

    private void autoDestroyForPosition() {
        if (transform.position.x <= -25.0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        GameObject explosion = Instantiate(explosionSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }
}