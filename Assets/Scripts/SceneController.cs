using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject gameOverCanvas;

    private bool playerDestroy = false;
    private float initialTime = 0;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {
        if (playerDestroy == true) {
            if (initialTime > 2.0) {
                Time.timeScale = 0;
                gameOverCanvas.SetActive(true);
            } else {
                initialTime += Time.deltaTime;
            }
        }
    }

    public void loadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void gameOver() {
        playerDestroy = true;
        initialTime = 0;
    }
}