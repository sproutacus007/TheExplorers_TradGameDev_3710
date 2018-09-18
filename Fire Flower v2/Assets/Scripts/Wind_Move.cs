using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wind_Move : MonoBehaviour {

    public float extraGravity = 10f;
    public float verticalWind = 1f;
    public float lowWind = 1f;
    public float midWind = 3f;
    public float highWind = 5f;
    public float maxSpeed = 15f;
    public float maxHeight = 20f;
    public float timeToMid = 3f;
    public float timeToHigh = 5f;
    public float sizeBeforeGrow = 3f;
    public Vector3 growthFactors = new Vector3(.2f, .2f, .2f);


    private float windCounter = 0f;
    private Rigidbody sparkRigid;
    private Transform sparkSize;

	// Use this for initialization
	void Start () {
        sparkRigid = this.GetComponent<Rigidbody>();
        sparkSize = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0f;
        float windSpeed = lowWind;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveY = verticalWind;
            windCounter += Time.deltaTime;
            if (windCounter > timeToHigh)
            {
                windCounter = timeToHigh;
            }
        }
        else if (windCounter > 0)
        {
            windCounter = Math.Max(0, windCounter - 2*Time.deltaTime);
        }

        if (windCounter >= timeToMid)
        {
            windSpeed = midWind;
        }
        if (windCounter >= timeToHigh)
        {
            windSpeed = highWind;
        }


        Vector3 movement = new Vector3(moveX, moveY, moveZ);
        sparkRigid.AddForce(movement * windSpeed, ForceMode.Acceleration);

        var v = sparkRigid.velocity;
        if (sparkRigid.velocity.magnitude > maxSpeed)
        {
            sparkRigid.velocity = v.normalized * maxSpeed;
        }
        if (sparkRigid.position.y > maxHeight)
        {
            sparkRigid.AddForce(0f, -extraGravity, 0f);
        }

        if (windSpeed == highWind && sparkSize.localScale.x < sizeBeforeGrow)
        {
            sparkSize.localScale -= growthFactors * Time.deltaTime;
            Debug.Log("Shrinking");
        }
        else if (windSpeed == highWind)
        {
            sparkSize.localScale += growthFactors * Time.deltaTime;
        }
	}
}
