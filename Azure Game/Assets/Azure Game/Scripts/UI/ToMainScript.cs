using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainScript : MonoBehaviour {

    public void nextScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu Scene");
    }
}
