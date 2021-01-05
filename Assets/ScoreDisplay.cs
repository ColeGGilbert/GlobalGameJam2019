using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
        GameObject gameEngine = GameObject.FindGameObjectWithTag("GameEngine");
        GetComponent<TMP_Text>().text = gameEngine.GetComponent<Score>().score.ToString();
	}
	
}
