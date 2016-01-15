using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    float lockPos = 0;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(lockPos, 270, lockPos);
        transform.position = new Vector3(10, player.transform.position.y, player.transform.position.z + 10);
    }
}
