using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    float highestPosition;
    public int score = 0;
    public int lvl = 0;

    public Player player;
    public Text scoreText;
    public Text lvlText;
    // Use this for initialization
    void Start () {
        player.OnPlayerEscaped += OnPlayerEscaped;
        player.OnPlayerMoved += OnPlayerMoved;
        highestPosition = player.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnPlayerMoved()
    {
        if(player.transform.position.y > highestPosition)
        {
            highestPosition = player.transform.position.y;
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    void OnPlayerEscaped()
    {
        highestPosition = player.transform.position.y;
        lvl++;
        lvlText.text = "Level: " + lvl;
    }
}
