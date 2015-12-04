using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public GameObject Door;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            StartCoroutine(Door.GetComponent<DoorScript>().OpenUp());
    }
}
