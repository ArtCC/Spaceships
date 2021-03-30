using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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
    }

    // Private functions
    void changeSprite() {
        if (vertical == 1) {
            sRender.sprite = upSprite;
        } else if (vertical == 0) {
            sRender.sprite = normalSprite;
        } else if (vertical == -1) {
            sRender.sprite = downSprite;
        }
    }
}