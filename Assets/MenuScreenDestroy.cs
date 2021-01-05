using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenDestroy : MonoBehaviour {

	public CollapseMenuScreen menuObjs;

	// Update is called once per frame
	void Update () {
		if (transform.position.x >= 15){
			transform.position = new Vector2(-15, 0);
			menuObjs.MakeReset();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Block")
		{
			collision.gameObject.GetComponent<Fall>().MakeFall();
		}
	}
}
