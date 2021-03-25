using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public string LeveltoLoad = "";
    public GameObject Player;
    public Health HealthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Rocket");
        HealthPlayer = Player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rocket")
        {
            Application.LoadLevel(LeveltoLoad);
        }
    }
}
