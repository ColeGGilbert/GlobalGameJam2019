using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBoxMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player"))
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, -10, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            ResetLevelScene.m_instance.ResetLevel();
		}
	}
}
