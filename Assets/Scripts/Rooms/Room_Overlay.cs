using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Overlay : MonoBehaviour {

    SpriteRenderer sprite;
    Color tmp;

    bool inRoom = false;
    
    // Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !inRoom)
        {
            inRoom = true;
            SetAlpha();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && inRoom)
        {
            inRoom = false;
            SetAlpha();
        }
    }

    void SetAlpha()
    {
        if (inRoom)
            tmp.a = 0f;
        else
            tmp.a = 1f;

        sprite.color = tmp;
    }
}
