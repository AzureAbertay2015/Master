﻿using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */
    public Vector3 OpenPosition;
    public Vector3 ClosePosition;

    private bool open;

    public void Start()
    {
        OpenPosition = transform.position;
        OpenPosition.y += transform.position.y + 20;
        ClosePosition = transform.position;
    }

    public void DoActivateTrigger()
    {
        if (!open)
        {
            StartCoroutine(OpenUp());
        }        
    }

    public void DoDeactivateTrigger()
    {
        if (open)
        {
            StartCoroutine(Close());
        }
    }

    public IEnumerator OpenUp()
    {
        if (!open)
        {
            while(transform.position!=OpenPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, OpenPosition, 0.1f);
                if (Vector3.Distance(transform.position, OpenPosition) <= 0.01f)
                {
                    transform.position = OpenPosition;
                    open = true;
                }
                yield return null;
            }
        }
    }

    public IEnumerator Close()
    {
        if (open)
        {
            while(transform.position!=ClosePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, ClosePosition, 0.1f);
                if (Vector3.Distance(transform.position, ClosePosition) <= 0.01f)
                {
                    transform.position = ClosePosition;
                    open = false;
                }
                yield return null;
            }
        }
    }

    public bool IsOpen()
    {
        return open;
    }
}
