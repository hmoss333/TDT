using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_Transition : MonoBehaviour {

    public bool isEntrance;

    Camera mainCam;
    
    // Use this for initialization
	void Start () {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (isEntrance)
            {
                //mainCam.gameObject.SetActive(false);
                SceneManager.LoadScene("2D_Test", LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("2D_Test"));
                col.GetComponent<Player_Movement>().interacting = true;
            }
        }
    }
}
