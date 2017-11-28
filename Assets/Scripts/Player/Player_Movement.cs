using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed;
    public float checkDist;

    float xInput;
    float yInput;

    Rigidbody2D rb2d;

    Vector3 previousGood = Vector3.zero;
    RaycastHit2D foundHit;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector2(xInput, yInput) * speed;
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
            }
        }
    }
}
