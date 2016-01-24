using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playScript : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
