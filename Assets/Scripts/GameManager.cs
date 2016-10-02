using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public void Win() {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
    }

    public void Defeat() {
        Time.timeScale = 0;
        loseCanvas.SetActive(true);
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Tomb");
    }

}
