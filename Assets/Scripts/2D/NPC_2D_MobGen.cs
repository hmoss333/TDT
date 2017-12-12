using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D_MobGen : MonoBehaviour {

    public GameObject[] npcMob;
    public float spawnRate;

    public bool spawning;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawning)
        {
            //spawnRate = Random.Range(0.25f, 1f);
            StartCoroutine(SpawnMob());
        }
	}

    IEnumerator SpawnMob ()
    {
        GameObject prefab;

        spawning = true;
        yield return new WaitForSeconds(spawnRate);
        prefab = Instantiate(npcMob[Random.Range(0, npcMob.Length)], new Vector2(1.5f, 0), Quaternion.identity);
        spawning = false;
    }
}
