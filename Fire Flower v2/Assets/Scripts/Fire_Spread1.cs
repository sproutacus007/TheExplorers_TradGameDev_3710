using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire_Spread1 : MonoBehaviour {

    public Vector3 shrinkFactor = new Vector3(.1f, .1f, .1f);


	void OnTriggerStay(Collider other)
    {
        other.transform.localScale -= shrinkFactor * Time.deltaTime;

    }

}
