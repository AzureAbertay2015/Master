using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StateUIScript : MonoBehaviour {

    private Text m_stateText;

    // Use this for initialization
    void Start ()
    {
        m_stateText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerControls.m_State == PlayerControls.State.Solid)
        {
            m_stateText.text = "Solid";
        }
        if (PlayerControls.m_State == PlayerControls.State.Liquid)
        {
            m_stateText.text = "Liquid";
        }
        if (PlayerControls.m_State == PlayerControls.State.Gas)
        {
            m_stateText.text = "Gas";
        }
    }
}
