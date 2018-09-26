using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dash_Move : MonoBehaviour {

    public float dashSpeed = 50f;
    public float maxSpeed = 50f;
    public float maxHeight = 20f;
    public GameObject spark;
    public GameObject player;
    private Rigidbody playerRigid;
    private Transform sparkSize;
    private Transform sparkOriginalSize;
    public KeyCode dashKey = KeyCode.Space;
    private Transform playerDirection;

    private void Start()
    {
        sparkOriginalSize = spark.transform;
    }

    // Update is called once per frame
    void Update () {
        playerRigid = player.GetComponent<Rigidbody>();
        sparkSize = spark.transform;
        playerDirection = player.transform;

		if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dashing");
            playerRigid.AddForce(playerDirection.forward * dashSpeed);
            //playerRigid.Add

            //spark trail to leave behind will have a mass equal to sparkSize.localScale / 8

            sparkSize.localScale -= sparkSize.localScale / 8; //shrinks the spark size because of dash
        }
	}
}
