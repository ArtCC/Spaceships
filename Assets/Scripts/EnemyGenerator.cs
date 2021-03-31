using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public float maxTime;
    public float height;
    
    public GameObject enemy;
    
    private float initialTime = 0;

    // Start is called before the first frame update
    void Start() {
        generateEnemy(-height, height);
    }

    // Update is called once per frame
    void Update() {
        if (initialTime > maxTime) {
            generateEnemy(-height, height);
        } else {
            initialTime += Time.deltaTime;
        }
    }

    private void generateEnemy(float x, float y) {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = transform.position + new Vector3(0, Random.Range(x, y), 0);
        Destroy(newEnemy, 20);
        
        initialTime = 0;
    }
}