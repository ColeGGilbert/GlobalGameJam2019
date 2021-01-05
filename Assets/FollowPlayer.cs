using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
    private GameObject player;
    private Transform tran;
    public float clampRange = 10;

    private void OnEnable()
    {
        ResetLevelScene.OnReset += ResetPos;
    }

    // Use this for initialization
    void Start ()
    {
        tran = transform;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1.25f + VariablesBetweenNights.currentNight / 4.25f;
    }

    void ResetPos()
    {
        speed = 1.25f + VariablesBetweenNights.currentNight / 4.25f;
    }
	
	// Update is called once per frame
	void Update () {

		rb.velocity = Vector2.right * speed;
		if (player != null)
		{
            if (player.activeSelf)
            {
			    if (transform.position.x < player.transform.position.x - clampRange)
			    {
				    transform.position = new Vector3(player.transform.position.x - clampRange, transform.position.y);
			    }
            }
		}
	}
}
