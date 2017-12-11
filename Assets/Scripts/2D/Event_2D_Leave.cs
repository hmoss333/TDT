using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_2D_Leave : MonoBehaviour {

    GameObject entrance;
    GameObject exit;

    Player_Movement player;
    Camera mainCam;

    public bool isExit;
    
    // Use this for initialization
	void Start () {
        entrance = GameObject.Find("Enter");
        exit = GameObject.Find("Exit");

        player = GameObject.FindObjectOfType<Player_Movement>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("2D_Test"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (isExit)
            {
                Debug.Log("made it!");
                player.gameObject.transform.position = exit.transform.position;
                player.lastInput = Player_Movement.LastInput.right;
            }
            else
            {
                Debug.Log("not good enough...");
                player.gameObject.transform.position = entrance.transform.position;
                player.lastInput = Player_Movement.LastInput.left;
            }

            SceneManager.UnloadSceneAsync("2D_Test");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));

            mainCam.gameObject.SetActive(true);
            player.interacting = false;
        }
    }
}
