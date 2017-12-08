using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CameraFollow : MonoBehaviour {

    Player_Movement player;
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        // Temporary vector
        Vector3 temp = player.transform.position;
        //temp.x = temp.x - gameObject.transform.position.x;
        //temp.y = temp.y - gameObject.transform.position.y;
        temp.z = -10f;
        // Assign value to Camera position
        //transform.position = temp * Time.deltaTime; //"drunk" camera follow; save for later
        transform.position = temp;
    }
}
