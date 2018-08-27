using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ShowStats : MonoBehaviour {

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log(name + "inertia tensor" + rigidbody.inertiaTensor);
        Debug.Log(name + "COM" + rigidbody.centerOfMass);
	}
}
