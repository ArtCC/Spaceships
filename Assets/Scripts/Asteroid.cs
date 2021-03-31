using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float velocity;

    public AudioClip explosionSound;
    public GameObject explosionSprite;

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.left * velocity * Time.deltaTime;
    }

    // Private functions
    private void OnCollisionEnter2D(Collision2D other) {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        GameObject explosion = Instantiate(explosionSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 1);
    }
}
