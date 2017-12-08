using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //increment value or add to inventory
            Debug.Log("Picked up item");
            Destroy(this.gameObject);
        }
    }
}
