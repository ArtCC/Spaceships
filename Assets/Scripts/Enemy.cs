using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip explosionSound;
    public GameObject shoot;
    public GameObject explosionSprite;
    
    public float velocity;

    private Transform playerTransform;
    private Player player;
    private float lastShoot;

    // Start is called before the first frame update
    void Start() {      
        if (FindObjectOfType<Player>() != null) {
            player = FindObjectOfType<Player>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (player != null) {
            playerTransform = player.transform;

            var distance = Vector3.Distance(playerTransform.position, transform.position);
            Debug.Log("Distance to player" + distance);
        }

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