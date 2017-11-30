using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interact : MonoBehaviour {

    public string text;
    //public bool interacting;

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
        Debug.Log("Displaying Text...");

        uiBox.SetActive(true);
        textBubble.text = text;
        StartCoroutine(WaitForInput());
    }

    IEnumerator WaitForInput ()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Waiting for Input...");

        while (!Input.GetButton("Jump"))
            yield return null;

        uiBox.SetActive(false);
        player.interacting = false;
    }
}
