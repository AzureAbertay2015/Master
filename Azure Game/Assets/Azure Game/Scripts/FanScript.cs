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

	void OnCollisionStay(Collision collisionInfo)
	{
		
		if (collisionInfo.gameObject.tag == "Player")
		{
			collisionInfo.gameObject.GetComponent<Rigidbody>().AddForce(0, 20, 0);
			
		}
		Debug.Log(collisionInfo.gameObject.tag);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Rigidbody>().AddForce(0, 20, 0);
			
		}
		Debug.Log(other.gameObject.tag);
	}
}
