using UnityEngine;
using System.Collections;

public class FanScript : MonoBehaviour {

	public float m_FanForce = 5.0f;
	public Player m_Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.GetComponent<Rigidbody>().AddForce(transform.up * m_FanForce * Time.deltaTime, ForceMode.Acceleration);
		}
	}
}
