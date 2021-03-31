using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
    }

    public void loadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void gameOver() {
        gameOverCanvas.SetActive(true);
    }
}