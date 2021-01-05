using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseMenuScreen : MonoBehaviour {

	private float spawnDelay;
	private float nextXPos;

	public GameObject[] safeBlocks;
	public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
		nextXPos = -15f;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnDelay < 0 && nextXPos <= 15)
		{
			int typeOfBlock = Random.Range(0, 8);
			if (typeOfBlock > 3)
			{
				int index = Random.Range(0, obstacles.Length);
				GameObject segment = Instantiate(obstacles[index], new Vector3(nextXPos, -4, 0), Quaternion.identity);
			}
			else
			{
				int index = Random.Range(0, safeBlocks.Length);
				GameObject segment = Instantiate(safeBlocks[index], new Vector3(nextXPos, -4, 0), Quaternion.identity);
			}
			spawnDelay = 0.1f;
			nextXPos += 0.8f;
		}
		else
		{
			spawnDelay -= Time.deltaTime;
		}
	}

	public void MakeReset()
	{
		StartCoroutine(Reset());
	}

	IEnumerator Reset()
	{
		yield return new WaitForSeconds(0.1f);
		nextXPos = -10;
	}
}
