using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int score;

    public static string gameOver;

    Text text;

    void Awake () {
        text = GetComponent <Text> ();

        score = 0;
    }

    void Update () {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = score.ToString(gameOver);
    }
}