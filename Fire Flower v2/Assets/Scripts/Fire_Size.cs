using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire_Size : MonoBehaviour {

    public float timeToGrow = 1f;
    public Vector3 growthFactors = new Vector3(.2f, .2f, .2f);
    private float growCounter = 0f;
    private Rigidbody sparkRB;
    private Transform sparkSize;

	// Use this for initialization
	void Start () {
        sparkRB = this.GetComponent<Rigidbody>();
        sparkSize = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (growCounter >= timeToGrow)
        {
            sparkSize.localScale += growthFactors*Time.deltaTime;
        }

	}

    void OnCollisionStay(Collision coll)
    {
        growCounter = Math.Min(2, growCounter + Time.deltaTime);
        
    }

    private void OnCollisionExit(Collision collision)
    {
        growCounter = 0f;
    }
}
