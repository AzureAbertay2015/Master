using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    float lockPos = 0.0f;
    //private GameObject player;
    private Vector3 newPos;
    public Vector3 cameraOffset;
    
    // Use this for initialization
    void Start()
    {
        cameraOffset = new Vector3(0, 2, 15);
        newPos = transform.position;
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(lockPos, 180, lockPos);
        var player = GameObject.FindGameObjectWithTag("Player");
        newPos.x = player.transform.position.x + cameraOffset.x;
        newPos.y = player.transform.position.y + cameraOffset.y;
        newPos.z = player.transform.position.z + cameraOffset.z;
        transform.position = newPos;
    }
}
