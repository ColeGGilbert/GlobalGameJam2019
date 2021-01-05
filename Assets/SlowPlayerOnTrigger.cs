using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayerOnTrigger : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<MoveRightTemp>().SlowPlayer();
		}
	}
}
