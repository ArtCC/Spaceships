using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {

    public float maxTime;
    public float height;
    
    public GameObject asteroid;
    
    private float initialTime = 0;

    // Start is called before the first frame update
    void Start() {
        generateAsteroid(-height, height);
    }

    // Update is called once per frame
    void Update() {
        if (initialTime > maxTime) {
            generateAsteroid(-height, height);
        } else {
            initialTime += Time.deltaTime;
        }
    }

    private void generateAsteroid(float x, float y) {
        GameObject newAsteroid = Instantiate(asteroid);
        newAsteroid.transform.position = transform.position + new Vector3(0, Random.Range(x, y), 0);
        Destroy(newAsteroid, 10);
        
        initialTime = 0;
    }
}