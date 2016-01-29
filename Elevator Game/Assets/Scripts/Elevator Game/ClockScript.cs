using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour {
    
    private float m_time;
    private Text m_timeText;

    // Use this for initialization
    void Start()
    {
        m_timeText = GetComponent<Text>();
        m_time = 0;
    }

	void Awake ()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_time += Time.deltaTime;
        m_timeText.text = timeConvert(m_time);
    }

    string timeConvert(float time)
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (Mathf.Floor(time)).ToString("00");
        string milliSeconds = ((time * 100) % 100).ToString("00");

        return minutes + ":" + seconds + ":" + milliSeconds;
    }
}
