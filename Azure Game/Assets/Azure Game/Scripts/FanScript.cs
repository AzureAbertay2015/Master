﻿using UnityEngine;
using System.Collections;

public class FanScript : MonoBehaviour {

	public float m_FanForce = 5.0f;
	public Player m_Player;
	public GameManager m_GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (m_GameManager.m_State == GameManager.PlayerState.Gas)
				other.gameObject.GetComponent<Rigidbody>().AddForce(0, 20, 0);
			
		}
		//Debug.Log(other.gameObject.tag);
	}
}
