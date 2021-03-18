using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class NewBehaviourScript : MonoBehaviour
    
{
    public float AscendForce= 10f;
    public float tiltForce= 10f;
    public Rigidbody rb;
    bool Ascend = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float tiltHorizontal = Input.GetAxis("Horizontal");
        float tiltVertical = Input.GetAxis("Vertical");
        Ascend = Input.GetKey(KeyCode.Space);


        if (!Mathf.Approximately(tiltHorizontal, 0f) || !Mathf.Approximately(tiltVertical,0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new UnityEngine.Vector3(tiltVertical * tiltForce * Time.deltaTime, 0f, -tiltHorizontal *tiltForce * Time.deltaTime)));

        }
        rb.freezeRotation = false;

        if (Ascend)
        {
            rb.AddRelativeForce(UnityEngine.Vector3.up * AscendForce * Time.deltaTime);
        }

    }



    private void FixedUpdate()
    {
    }
}
