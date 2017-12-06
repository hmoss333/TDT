﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interact : MonoBehaviour {

    public string[] text;
    int currentText;

    Text textBubble;
    GameObject uiBox;
    bool waitForInput;

    Player_Movement player;

    private void Awake()
    {
        textBubble = GameObject.Find("Text").GetComponent<Text>();
        uiBox = GameObject.Find("UIBox");
    }

    // Use this for initialization
    void Start () {
        //interacting = false;
        player = GameObject.FindObjectOfType<Player_Movement>();

        if (uiBox.activeSelf)
            uiBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && waitForInput)
            waitForInput = false;
        else
            waitForInput = true;
	}

    public void DisplayText ()
    {
        Debug.Log("Displaying Text: " + currentText);

        uiBox.SetActive(true);
        textBubble.text = text[currentText];
        StartCoroutine(WaitForInput());
    }

    IEnumerator WaitForInput ()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("Waiting for Input...");

        while (waitForInput)
            yield return null;

        if (currentText < text.Length - 1) //If there are still text options to go through
        {
            currentText++;
            waitForInput = false;
            DisplayText();
        }
        else //If the player has reached the end of the text options
        {
            currentText = 0;
            uiBox.SetActive(false);
            player.interacting = false;
        }
    }
}
