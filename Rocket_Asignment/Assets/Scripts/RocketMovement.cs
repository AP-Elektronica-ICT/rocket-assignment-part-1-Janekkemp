using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;

public class RocketMovement : MonoBehaviour
    
{
    public float AscendForce= 10f;
    public float tiltForce= 10f;
    public Rigidbody rb;
    bool Ascend = false;
    public GameObject Player;
    public Health HealthPlayer;
    public TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.FindWithTag("Rocket");
        HealthPlayer = Player.GetComponent<Health>();
        tr = Player.GetComponent<TrailRenderer>();
       
        //Check if Lives need to be transferred to Level 2 from Level 1
        if (PlayerPrefs.HasKey("Lives"))
        {
            if(SceneManager.GetActiveScene().name == "1_Level")
            {
                HealthPlayer.numberOfLives = 7;
            }
            else 
            {
                HealthPlayer.numberOfLives = PlayerPrefs.GetInt("Lives");
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Reset control when respawn
        if (HealthPlayer.healthPoints <= 0)
        {
            Reset();
           
        }
        float tiltHorizontal = Input.GetAxis("Horizontal");
        float tiltVertical = Input.GetAxis("Vertical");
        Ascend = Input.GetKey(KeyCode.Space);

        PlayerPrefs.SetInt("Lives", HealthPlayer.numberOfLives);

        if (!Mathf.Approximately(tiltHorizontal, 0f) || !Mathf.Approximately(tiltVertical,0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new UnityEngine.Vector3(-tiltVertical * tiltForce * Time.deltaTime, 0f, tiltHorizontal *tiltForce * Time.deltaTime)));
            tr.time = 0.75f;
        }
        rb.freezeRotation = false;

        if (Ascend)
        {
            tr.time = 0.75f;
            rb.AddRelativeForce(UnityEngine.Vector3.up * AscendForce * Time.deltaTime);
        }

    }
    public void Reset()
    {
        rb.velocity = UnityEngine.Vector3.zero;
        rb.angularVelocity = UnityEngine.Vector3.zero;
        tr.time = 0;
    }
}
