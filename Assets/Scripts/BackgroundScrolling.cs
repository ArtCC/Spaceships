using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

    public float velocity;
    
    private MeshRenderer backgroundImage;

    // Start is called before the first frame update
    void Start() {
        backgroundImage = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        backgroundImage.material.mainTextureOffset = new Vector3(Time.time * velocity * 1f, 0, 0);
    }
}
