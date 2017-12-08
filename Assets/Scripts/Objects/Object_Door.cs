using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Door : MonoBehaviour {

    //[HideInInspector]
    public bool canUse;
    public enum ExitDir { up, left, right, down }
    public ExitDir exitDir;

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
	}
	
	// Update is called once per frame
	void Update () {
        if (!canUse)
        {
            player.interacting = true;
            player.transform.position += tempDir * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        anim.SetTrigger("Enter");
        //player.interacting = false;

        if (col.tag == "Player" && canUse)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            col.gameObject.transform.position = doorExit.transform.position;
            cam.gameObject.transform.position = col.gameObject.transform.position;
            doorExit.GetComponent<Object_Door>().canUse = false;
            doorExit.GetComponent<Object_Door>().MoveOutOfDoor();
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        anim.SetTrigger("Exit");

        if (col.tag == "Player" && !canUse)
        {
            canUse = true;
            //StartCoroutine(WaitToFinish());
        }
    }

    void MoveOutOfDoor()
    {
        switch (exitDir)
        {
            case ExitDir.up:
                tempDir = new Vector2(0, 1f);
                player.lastInput = Player_Movement.LastInput.up;
                Debug.Log("Move Up");
                break;
            case ExitDir.left:
                tempDir = new Vector2(-1f, 0);
                player.lastInput = Player_Movement.LastInput.left;
                Debug.Log("Move Left");
                break;
            case ExitDir.right:
                tempDir = new Vector2(1f, 0);
                player.lastInput = Player_Movement.LastInput.right;
                Debug.Log("Move Right");
                break;
            case ExitDir.down:
                tempDir = new Vector2(0, -1f);
                player.lastInput = Player_Movement.LastInput.down;
                Debug.Log("Move Down");
                break;
            default:
                Debug.Log("I'm not even mad, thats impressive");
                break;
        }

        StartCoroutine(WaitToFinish());
    }

    IEnumerator WaitToFinish()
    {
        Debug.Log("moving...");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length - 0.5f);
        player.interacting = false;
        Debug.Log("moved");
    }
}
