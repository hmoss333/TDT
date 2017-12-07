using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Door : MonoBehaviour {

    public bool canUse;
    string lastInput;
    bool moving = false;

    public GameObject doorExit;

    Camera cam;
    Animator anim;
    Player_Movement player;
    Vector3 tempDir;
    
    // Use this for initialization
	void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player_Movement>();

        //anim.SetTrigger("Idle");
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            player.transform.position += tempDir * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        anim.SetTrigger("Enter");

        if (col.tag == "Player" && canUse)
        {
            canUse = false;
            Debug.Log("Using door");
            col.gameObject.transform.position = doorExit.transform.position;
            cam.gameObject.transform.position = col.gameObject.transform.position;
            doorExit.GetComponent<Object_Door>().canUse = false;

            lastInput = col.GetComponent<Player_Movement>().lastInput;
            doorExit.GetComponent<Object_Door>().MoveOutOfDoor(col.gameObject, lastInput);
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        anim.SetTrigger("Exit");

        if (col.tag == "Player" && !canUse)
        {
            canUse = true;
            moving = false;
        }
    }

    void MoveOutOfDoor(GameObject target, string direction)
    {
        switch (direction)
        {
            case "up":
                tempDir = new Vector2(0, 1f);
                break;
            case "left":
                tempDir = new Vector2(-1f, 0);
                break;
            case "right":
                tempDir = new Vector2(1f, 0);
                break;
            case "down":
                tempDir = new Vector2(0, - 1f);
                break;
            default:
                break;
        }

        moving = true;
    }
}
