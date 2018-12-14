using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D_Bump : MonoBehaviour {

    public float speed;
    public float destroyTime;
    bool bumpedPlayer = false;
    public float playerInputModifyer;

    SpriteRenderer sr;
    BoxCollider2D boxCol;
    Vector2 dir;
    Player_2D_Move player;

    private Camera mainCamera;
    Vector2 screenPosition;
    bool foundCam;
    public Vector2 widthThresold;

    float leftConstraint;
    float buffer = 0.5f;
    float distanceZ;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        boxCol = this.GetComponent<BoxCollider2D>();
        player = GameObject.FindObjectOfType<Player_2D_Move>();
        dir = new Vector2(-speed, 0);
        mainCamera = Camera.main;

        speed = Random.Range(0.1f, 0.75f);
        sr.sortingOrder = Random.Range(0, 3);

        distanceZ = Mathf.Abs(mainCamera.transform.position.z + transform.position.z);
        leftConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            transform.Translate(dir * Time.deltaTime);
    }

    void Update()
    {
        if (transform.position.x < leftConstraint - buffer)
            Destroy(this.gameObject);

        if (bumpedPlayer && Input.anyKeyDown)
            destroyTime -= playerInputModifyer;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            bumpedPlayer = true;
            player.bumping = true;
            StartCoroutine(TimedColliderDestroy());
        }
    }

    IEnumerator TimedColliderDestroy ()
    {
        //yield return new WaitForSeconds(destroyTime);
        while (destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;
            Debug.Log(destroyTime);
            yield return null;
        }
        player.bumping = false;
        Destroy(boxCol);
    }
}
