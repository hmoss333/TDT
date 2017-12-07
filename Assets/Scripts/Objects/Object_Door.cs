using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Door : MonoBehaviour {

    public bool canUse;

    public GameObject doorExit;

    Camera cam;
    Animator anim;
    
    // Use this for initialization
	void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();

        //anim.SetTrigger("Idle");
	}
	
	// Update is called once per frame
	void Update () {
        //if (canUse)
        //    anim.SetTrigger("Idle");
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        anim.SetTrigger("Enter");
        Debug.Log("enter");

        if (col.tag == "Player" && canUse)
        {
            canUse = false;
            Debug.Log("Using door");
            col.gameObject.transform.position = doorExit.transform.position;
            cam.gameObject.transform.position = col.gameObject.transform.position;
            doorExit.GetComponent<Object_Door>().canUse = false;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        anim.SetTrigger("Exit");
        Debug.Log("exit");

        if (col.tag == "Player" && !canUse)
        {
            canUse = true;
        }
    }
}
