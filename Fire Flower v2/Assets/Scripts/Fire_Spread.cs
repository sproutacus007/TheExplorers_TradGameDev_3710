using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire_Spread : MonoBehaviour {

    public float timeToIgnite = 1f;
    public Vector3 growFactor = new Vector3(.5f, .5f, .5f);

    private float igniteCounter = 0f;
    private bool onFire = false;
    private Renderer rend;

    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }

	void OnTriggerStay(Collider other)
    {
        if (!onFire)
        {
            igniteCounter += Time.deltaTime;
            if (igniteCounter >= timeToIgnite)
            {
                onFire = true;
                rend.material.color = Color.red;
                other.transform.localScale += growFactor;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        igniteCounter = 0;
    }
}
