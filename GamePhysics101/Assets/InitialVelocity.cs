using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour {

    public Vector3 Velocity;
    public Vector3 initialW;
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().velocity = Velocity;
        this.GetComponent<Rigidbody>().angularVelocity = initialW;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
