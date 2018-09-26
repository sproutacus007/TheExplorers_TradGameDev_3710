﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire_Spread : MonoBehaviour {

    public float timeToIgnite = 1f;
    public Vector3 growFactor = new Vector3(2f, 2f, 2f);
    public GameObject fireState;
    public float mass;
    public float maxSize = 16f;

    private float igniteCounter = 0f;
    private bool onFire = false;
    private Renderer rend;
    private Collider fire;
    private bool colliding = false;

    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

	void OnTriggerStay(Collider other)
    {
        colliding = true;
        fire = other;
        if (!onFire)
        {
            igniteCounter += Time.deltaTime;
            if (igniteCounter >= timeToIgnite)
            {
                onFire = true;
                rend.material.color = Color.red; //in final version switch object with fire state
            }
        }

    }

    private void FixedUpdate()
    {
        if (colliding && onFire && fire.transform.localScale.magnitude <= maxSize)
            fire.transform.localScale += growFactor * Time.deltaTime;
    }

    void OnTriggerExit(Collider other)
    {
        igniteCounter = 0;
        colliding = false;
    }
}
