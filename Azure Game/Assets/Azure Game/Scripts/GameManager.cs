using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public enum PlayerState { Solid, Liquid, Gas };
	public enum Temperature { Cold, Warm, Hot };

	public PlayerState m_State;
	public Temperature m_Temperature;
	

    //----------------------------------------
    // handles
    public UIManager UI;
	public Player player;

    //-----------------------------------------
    // function definitions
    void Start() {
		//player = GetComponent<Player>();
		m_State = PlayerState.Solid;
		m_Temperature = Temperature.Warm;
	}

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        //Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

	public void ChangeState(int state)
	{
		if (state > 0)
		{
			switch (state)
			{
				case 0:
					m_State = PlayerState.Solid;
					break;
				case 1:
					m_State = PlayerState.Liquid;
					break;
				case 2:
					m_State = PlayerState.Gas;
					break;
			}
		}
		else
		{
			//Debug.Log("GAMEMANAGER:: PlayerState: " + state);
		}
	}

	//public void ChangeTemperature(int temperature)

}