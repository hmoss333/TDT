using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Door : MonoBehaviour {

    public bool canUse;

    public GameObject doorExit;
    
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "Player" && canUse)
        {
            canUse = false;
            Debug.Log("Using door");
            col.gameObject.transform.position = doorExit.transform.position;
            doorExit.GetComponent<Object_Door>().canUse = false;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.tag == "Player" && !canUse)
        {
            canUse = true;
        }
    }
}
