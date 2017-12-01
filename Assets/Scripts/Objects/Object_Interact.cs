using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interact : MonoBehaviour {

    public string[] text;
    int currentText;

    public Text textBubble;
    public GameObject uiBox;

    Player_Movement player;

    // Use this for initialization
	void Start () {
        //interacting = false;
        player = GameObject.FindObjectOfType<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {

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
        yield return new WaitForSeconds(1f);
        Debug.Log("Waiting for Input...");

        while (!Input.GetButton("Jump"))
            yield return null;

        if (currentText < text.Length - 1) //If there are still text options to go through
        {
            currentText++;
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
