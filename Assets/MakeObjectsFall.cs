using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsFall : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Block")
		{
			collision.GetComponent<Fall>().MakeFall();
			WorldGen.totalSegments -= 1;
		}
		else if(collision.gameObject.tag == "Pickup")
		{
			collision.gameObject.GetComponent<Fall>().MakeFall();
		}
	}
}
