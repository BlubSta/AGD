using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectable : MonoBehaviour {

    private Text scoreUI;
    public int value;

    private int score;

    private void Start()
    {
       scoreUI = GameObject.Find("Score").GetComponent<Text>();
    }

    public void collect()
    {
        score = int.Parse(scoreUI.text);
        score += value;
        scoreUI.text = score + "";

        Destroy(gameObject);
    }
}
