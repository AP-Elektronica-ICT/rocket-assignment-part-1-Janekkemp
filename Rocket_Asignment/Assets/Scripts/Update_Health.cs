using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lives;
    public GameObject Player;
    public Health Healthplayer;
    public string amount = "";
    void Start()
    {
        Player = GameObject.FindWithTag("Rocket");
        lives = GameObject.FindWithTag("AmountLives");
        Healthplayer = Player.GetComponent<Health>();
       
    }

    // Update is called once per frame
    void Update()
    {
        amount = Healthplayer.numberOfLives.ToString();
        lives.GetComponent<Text>().text = amount;
    }
}
