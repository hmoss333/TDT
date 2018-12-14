using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_CrowdGen : MonoBehaviour {

    public int peopleNum;
    public GameObject[] students;

    public float randomMaxWidth;
    public float randomMaxHeight;
    
    // Use this for initialization
	void Start () {
        GenCrowd();
	}

    void GenCrowd ()
    {
        for (int i = 0; i < peopleNum; i++)
        {
            GameObject newPlayer = Instantiate(students[Random.Range(0, students.Length)], 
                new Vector2(Random.Range(transform.position.x-randomMaxWidth, transform.position.x + randomMaxWidth), Random.Range(transform.position.y - randomMaxHeight, transform.position.y + randomMaxHeight)), 
                Quaternion.identity);

            newPlayer.GetComponent<NPC_Rotate>().isRandom = true;

            if (newPlayer.GetComponent<Object_Interact_Parent>())
                Destroy(newPlayer.GetComponent<Object_Interact_Parent>());

            newPlayer.transform.parent = this.transform;
        }
    }
}
