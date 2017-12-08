using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed;
    public float checkDist;
    //[HideInInspector]
    public bool interacting;

    float xInput;
    float yInput;

    Vector3 dir;
    Rigidbody2D rb2d;
    Animator anim;
    [HideInInspector]
    public enum LastInput { up, left, right, down};
    public LastInput lastInput;

    Vector3 previousGood = Vector3.zero;
    RaycastHit2D foundHit;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        interacting = false;
	}

    void SetIdleAnimTriggers()
    {
        switch (lastInput)
        {
            case LastInput.up:
                anim.SetTrigger("IdleUp");
                break;
            case LastInput.left:
                anim.SetTrigger("IdleLeft");
                break;
            case LastInput.right:
                anim.SetTrigger("IdleRight");
                break;
            case LastInput.down:
                anim.SetTrigger("IdleDown");
                break;
            default:
                anim.SetTrigger("Idle");
                break;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!interacting)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");

            //Vector3 dir = new Vector2(xInput, yInput) * speed;

            if (xInput != 0)
            {
                dir = new Vector2(xInput * speed, 0);
                if (xInput > 0)
                {
                    anim.SetTrigger("MoveRight");
                    lastInput = LastInput.right;
                }
                else
                {
                    anim.SetTrigger("MoveLeft");
                    lastInput = LastInput.left;
                }
            }
            else if (yInput != 0)
            {
                dir = new Vector2(0, yInput * speed);
                if (yInput > 0)
                {
                    anim.SetTrigger("MoveUp");
                    lastInput = LastInput.up;
                }
                else
                {
                    anim.SetTrigger("MoveDown");
                    lastInput = LastInput.down;
                }
            }
            else
            {
                dir = new Vector2(0, 0);
                SetIdleAnimTriggers();
            }

            rb2d.velocity = dir;

            if (dir == Vector3.zero)
            {
                dir = previousGood;
            }
            else
            {
                previousGood = dir;
            }

            if (Input.GetButtonDown("Jump"))
            {
                foundHit = Physics2D.Raycast(transform.position, dir, checkDist, 1 << LayerMask.NameToLayer("Wall"));
                Debug.DrawRay(transform.position, dir, Color.green);

                if (foundHit.collider != null)
                {
                    Debug.Log("Looking at a thing: " + foundHit.transform.name);
                    foundHit.collider.gameObject.GetComponent<Object_Interact_Parent>().Interact();
                    interacting = true;
                }
            }
        }

        else
            SetIdleAnimTriggers();
    }
}
