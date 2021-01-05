using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;

    private void OnEnable()
    {
        ResetLevelScene.OnReset += ResetScore;
    }

    void ResetScore()
    {
        score = 0;
    }
}
