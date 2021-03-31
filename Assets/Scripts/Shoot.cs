using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed;
    public AudioClip sound;

    private Rigidbody2D rBody;
    private Vector2 customDirection = Vector2.right;

    // Start is called before the first frame update
    void Start() {
        rBody = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    // Update is called once per frame
    void Update() {
        rBody.velocity = customDirection * speed;
    }

    public void setDirection(Vector2 direction) {
        customDirection = direction;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}