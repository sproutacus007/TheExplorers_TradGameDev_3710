using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Fire_Size : MonoBehaviour {

    public float timeToGrow = 1f;
    public Vector3 shrinkFactors = new Vector3(.05f, .05f, .05f);
    public GameObject fireAura;
    public UnityEvent playerDeathEvent;
    private float growCounter = 0f;
    private Transform auraSize;
    private Transform auraOriginalSize;

    // Use this for initialization
    void Start () {
        auraSize = fireAura.transform;
        auraOriginalSize = fireAura.transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (auraSize.transform.lossyScale.magnitude < 0.01)
            playerDeathEvent.Invoke();
        else
        {
            auraSize.localScale -= shrinkFactors * Time.deltaTime;
        }
        
    }
        

	}

