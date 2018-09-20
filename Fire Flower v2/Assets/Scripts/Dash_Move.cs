using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dash_Move : MonoBehaviour {

    public float extraGravity = 10f;
    public float dashSpeed = 50f;
    public float maxSpeed = 50f;
    public float maxHeight = 20f;
    private GameObject spark;
    private Rigidbody sparkRigid;
    private Transform sparkSize;
    private Transform sparkOriginalSize;
    public KeyCode dashKey = KeyCode.Space;

    private void Start()
    {
        spark = GameObject.FindGameObjectWithTag("Player");
        sparkOriginalSize = spark.transform;
    }

    // Update is called once per frame
    void Update () {
        sparkRigid = spark.GetComponent<Rigidbody>();
        sparkSize = spark.transform;
		if(Input.GetKeyDown(KeyCode.Space))
        {
                Debug.Log("Dashing");
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");
                float moveY = 0f;
                Vector3 movement = new Vector3(moveX, moveY, moveZ);
                sparkRigid.AddForce(movement * dashSpeed, ForceMode.VelocityChange);

                //spark trail to leave behind will have a mass equal to sparkSize.localScale / 4

                sparkSize.localScale -= sparkSize.localScale / 4; //shrinks the spark size because of dash
        }
	}
}
