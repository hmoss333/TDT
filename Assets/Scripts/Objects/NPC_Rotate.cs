using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Rotate : MonoBehaviour {

	public enum LookDirection { up, left, right, down }
    public LookDirection lookDir;

    public bool isRandom;

    Animator anim;
    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Coroutine co = StartCoroutine(SetRotation());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SetRotation ()
    {
        switch (lookDir)
        {
            case LookDirection.up:
                anim.SetTrigger("LookUp");
                break;
            case LookDirection.left:
                anim.SetTrigger("LookLeft");
                break;
            case LookDirection.right:
                anim.SetTrigger("LookRight");
                break;
            case LookDirection.down:
                anim.SetTrigger("LookDown");
                break;
            default:
                anim.SetTrigger("LookDown");
                break;
        }

        yield return new WaitForSeconds(1f);

        if (isRandom)
        {
            int randNum = Random.Range(0, 4);

            switch (randNum)
            {
                case 0:
                    //anim.SetTrigger("LookUp");
                    lookDir = LookDirection.up;
                    break;
                case 1:
                    //anim.SetTrigger("LookLeft");
                    lookDir = LookDirection.left;
                    break;
                case 2:
                    //anim.SetTrigger("LookRight");
                    lookDir = LookDirection.right;
                    break;
                case 3:
                    //anim.SetTrigger("LookDown");
                    lookDir = LookDirection.down;
                    break;
                default:
                    lookDir = LookDirection.down;
                    break;
            }

            Coroutine co = StartCoroutine(SetRotation());
        }
    }
}
