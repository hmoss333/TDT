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
    public Vector2 widthThresold;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        boxCol = this.GetComponent<BoxCollider2D>();
        dir = new Vector2(-speed, 0);
        mainCamera = GameObject.FindObjectOfType<Camera>();

        speed = Random.Range(0.1f, 0.75f);
        sr.sortingOrder = Random.Range(0, 3);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(dir * Time.deltaTime);
	}

    void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x)
            Destroy(gameObject);
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
