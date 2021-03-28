using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity;
    public Sprite upSprite;
    public Sprite normalSprite;
    public Sprite downSprite;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector3 tempVect = new Vector3(horizontal, vertical, 0);
        tempVect = tempVect.normalized * velocity * Time.deltaTime;
        rigidbody2D.MovePosition(rigidbody2D.transform.position + tempVect);

        changeSprite();
    }

    // Private functions
    void changeSprite() {
        if (vertical == 1) {
            spriteRenderer.sprite = upSprite;
        } else if (vertical == 0) {
            spriteRenderer.sprite = normalSprite;
        } else if (vertical == -1) {
            spriteRenderer.sprite = downSprite;
        }
    }
}