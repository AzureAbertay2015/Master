using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            //save data
            
            //pause the game
            Application.LoadLevel("Menu Scene");
        }
    }
}
