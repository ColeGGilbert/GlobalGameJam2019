using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIncrease : MonoBehaviour {

	public static float currentTime;
	private float startTime;
	private bool moveToTop;
	private bool keepIncreasingTimer;

	private Text timeDisplay;

	// Use this for initialization
	void Start () {
		moveToTop = false;
		keepIncreasingTimer = true;
		startTime = Time.time;
		timeDisplay = GameObject.FindGameObjectWithTag("TimeDisplay").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (keepIncreasingTimer)
		{
			currentTime = Time.time - startTime;
			int minuteCount = (int)(currentTime / 60f);
			int secondCount = (int)(currentTime % 60f);
			timeDisplay.text = string.Format("Time: {0:00}:{1:00}", minuteCount, secondCount);
		}

		if (moveToTop)
		{
			Vector2.MoveTowards(transform.position, new Vector2(0, -50), 1);
		}
	}

	public void AtHouse()
	{
		moveToTop = true;
		keepIncreasingTimer = false;
	}
}
