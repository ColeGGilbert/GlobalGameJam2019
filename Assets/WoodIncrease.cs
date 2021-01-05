using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodIncrease : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			WorldGen.woodRemaining--;
            Debug.Log("Wood Remaining: " + WorldGen.woodRemaining);
            WorldGen.totalPickupsCollected++;
			Destroy(gameObject);
		}
	}

	private Text woodDisplay;

	private void Start()
	{
		woodDisplay = GameObject.FindGameObjectWithTag("WoodDisplay").GetComponent<Text>();
	}
	private void Update()
	{
		woodDisplay.text = "Wood Remaining: " + WorldGen.woodRemaining;
	}
}
