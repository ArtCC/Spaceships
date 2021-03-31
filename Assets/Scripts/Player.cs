using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    
    public AudioClip explosionSound;
    public GameObject shoot;
    public GameObject explosionSprite;
    public SceneController sceneController;

    public float velocity;
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;

    public Sprite upSprite;
    public Sprite normalSprite;
    public Sprite downSprite;

    private Rigidbody2D rBody;
    private SpriteRenderer sRender;
    
    private float horizontal;
    private float vertical;
    private float lastShoot;

    // Start is called before the first frame update
    void Start() {
        rBody = GetComponent<Rigidbody2D>();
        sRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector3 tempVect = new Vector3(horizontal, vertical, 0);
        tempVect = tempVect.normalized * velocity * Time.deltaTime;
        rBody.MovePosition(rBody.transform.position + tempVect);

        transform.position = new Vector3(Mathf.Clamp(
            transform.position.x, minX, maxX), 
            Mathf.Clamp(transform.position.y, minY, maxY), 
            transform.position.z);

        changeSprite();

        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25) {
            createShoot();
            lastShoot = Time.time;
        }
    }

    // Private functions
    private void changeSprite() {
        if (vertical == 1) {
            sRender.sprite = upSprite;
        } else if (vertical == 0) {
            sRender.sprite = normalSprite;
        } else if (vertical == -1) {
            sRender.sprite = downSprite;
        }
    }

    private void createShoot() {
        /**
        Vector3 direction;
        if (transform.localScale.x == 1.0f) {
            direction = Vector3.right;
        } else {
            direction = Vector3.left;
        }
        GameObject customShoot = Instantiate(shoot, transform.position + direction * 0.1f, Quaternion.identity);
        customShoot.GetComponent<Shoot>().setDirection(direction);*/

        // Set always right for this case.
        GameObject customShoot = Instantiate(shoot, transform.position + Vector3.right * 1.0f, Quaternion.identity);
        float getTime = Time.time;
        Destroy(customShoot, 3);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(explosionSound);
        GameObject explosion = Instantiate(explosionSprite, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 1);
        sceneController.gameOver();
    }
}