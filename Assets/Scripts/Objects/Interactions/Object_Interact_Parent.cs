using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Interact_Parent : MonoBehaviour {

    [HideInInspector]
    public Text textBubble;
    [HideInInspector]
    public GameObject uiBox;

    [HideInInspector]
    public Player_Movement player;

    [HideInInspector]
    public bool waitForInput;

    public virtual void Awake()
    {
        textBubble = GameObject.Find("Text").GetComponent<Text>();
        uiBox = GameObject.Find("UIBox");
    }

    // Use this for initialization
    public virtual void Start () {
        player = GameObject.FindObjectOfType<Player_Movement>();

        if (uiBox.activeSelf)
            uiBox.SetActive(false);
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (Input.GetButtonDown("Jump") && waitForInput)
            waitForInput = false;
        else
            waitForInput = true;
    }

    public virtual void Interact ()
    {
        waitForInput = false;
    }
}
