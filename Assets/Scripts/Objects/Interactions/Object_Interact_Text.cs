using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interact_Text : Object_Interact_Parent {

    public string[] text;
    int currentText;

    //Text textBubble;
    //GameObject uiBox;

    //bool waitForInput;

    // Use this for initialization
    //void Start () {
    //    base.Start();
    //}

    // Update is called once per frame
    //override public void Update()
    //{
    //    base.Update();
    //}

    override public void Interact()
    {
        base.Interact();
        DisplayText();
    }

    void DisplayText()
    {
        Debug.Log("Displaying Text: " + currentText);

        uiBox.SetActive(true);
        textBubble.text = text[currentText];
        StartCoroutine(WaitForInput());
    }

    IEnumerator WaitForInput()
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
