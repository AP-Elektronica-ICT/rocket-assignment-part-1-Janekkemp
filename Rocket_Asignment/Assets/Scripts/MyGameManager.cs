using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject ScoreCanvas;
    public GameObject GameOverCanvas;
    private Health HealthPlayer;

    public enum GameStates
    {
        Playing,
        GameOver
    }

    public GameStates Gamestate = GameStates.Playing;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null) ;
        {
            Player = GameObject.FindWithTag("Rocket");
        }
        HealthPlayer = Player.GetComponent<Health>();
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Gamestate)
        {
            case GameStates.Playing:
                if(!HealthPlayer.isAlive)
                {
                    Gamestate = GameStates.GameOver;
                    ScoreCanvas.SetActive(false);
                    GameOverCanvas.SetActive(true);
                }
                break;
        }
    }
}
