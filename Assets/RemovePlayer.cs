using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemovePlayer : MonoBehaviour {

	public GameObject background;
	public GameObject groundCover;
	public GameObject player;
	public GameObject tree;

	private bool changeCol;

    private void OnEnable()
    {
        ResetLevelScene.OnReset += ResetColours;
    }

    // Use this for initialization
    void Start () {
		changeCol = false;
		player = GameObject.FindGameObjectWithTag("Player");
		background = GameObject.FindGameObjectWithTag("Background");
		groundCover = GameObject.FindGameObjectWithTag("DirtCover");
		tree = GameObject.FindGameObjectWithTag("Tree1");
	}
	
	// Update is called once per frame
	void Update () {
		if (changeCol)
		{
			background.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.0064f);
			groundCover.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.0064f);
			tree.GetComponent<SpriteRenderer>().color += new Color(0.0064f, 0.0064f, 0.0064f, 0);
		}
    }

    void ResetColours()
    {
        background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == player)
		{
			VariablesBetweenNights.currentNight += 1;
			GameObject.FindGameObjectWithTag("TimeDisplay").GetComponent<TimeIncrease>().AtHouse();
            player.SetActive(false);
			changeCol = true;
			StartCoroutine(EndGame());
		}
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(2.75f);
        ResetLevelScene.m_instance.ToggleEndgameScreen();
    }
}
