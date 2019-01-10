using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D_MobGen : MonoBehaviour {

    public GameObject[] npcMob;
    public float spawnRate;

    bool spawning;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawning)
        {
            //spawnRate = Random.Range(0.25f, 1f);
            StartCoroutine(SpawnMob(npcMob[Random.Range(0, npcMob.Length)], Random.Range(spawnRate / 2f, spawnRate)));
        }
	}

    IEnumerator SpawnMob (GameObject mobObject, float spawnTime)
    {
        GameObject prefab;

        spawning = true;
        yield return new WaitForSeconds(spawnTime);
        prefab = Instantiate(mobObject, new Vector2(1.5f, 0), Quaternion.identity);
        prefab.transform.parent = this.transform;
        spawning = false;
    }
}
