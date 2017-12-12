using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2D_Bump : MonoBehaviour {

    public float speed;
    public float destroyTime;

    SpriteRenderer sr;
    BoxCollider2D boxCol;
    Vector2 dir;

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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(TimedColliderDestroy());
        }
    }

    IEnumerator TimedColliderDestroy ()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(boxCol);
    }
}
