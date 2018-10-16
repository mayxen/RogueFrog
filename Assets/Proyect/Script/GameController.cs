using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    float highestPosition;
    public int score = 0;
    public int lvl = 0;
    public float dif =1.2f;
    public Player player;
    public Text scoreText;
    public Text lvlText;
    public Text gameOverText;
    private float restartTimer = 3f;
    // Use this for initialization
    void Start () {
        player.OnPlayerEscaped += OnPlayerEscaped;
        player.OnPlayerMoved += OnPlayerMoved;
        highestPosition = player.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
		if(player == null)
        {
            gameOverText.gameObject.SetActive(true);
            restartTimer -= Time.deltaTime;
            if(restartTimer <= 0)
            {
                SceneManager.LoadScene("Game");
            }
        }   

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
        foreach (EnemyController enemy in GetComponentsInChildren<EnemyController>())
        {
            enemy.speed *= dif;
        }
    }
}
