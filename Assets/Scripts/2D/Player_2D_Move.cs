using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D_Move : MonoBehaviour {

    public float speed;
    float xInput;

    Vector3 dir;
    Rigidbody2D rb2d;
    Animator anim;
    public enum LastInput { left, right };
    public LastInput lastInput;

    public SpriteRenderer inputSprite;
    [HideInInspector]
    public bool bumping = false;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        inputSprite.enabled = bumping;       
    }

    // Update is called once per frame
    void FixedUpdate () {
        xInput = Input.GetAxisRaw("Horizontal");

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
        else
        {
            dir = new Vector2(0, 0);
            SetIdleAnimTriggers();
        }

        rb2d.velocity = dir;
    }

    public void SetIdleAnimTriggers()
    {
        switch (lastInput)
        {
            case LastInput.left:
                anim.SetTrigger("IdleLeft");
                break;
            case LastInput.right:
                anim.SetTrigger("IdleRight");
                break;
            default:
                anim.SetTrigger("IdleRight");
                break;
        }
    }
}
