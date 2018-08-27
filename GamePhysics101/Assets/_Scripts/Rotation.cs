using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotation : MonoBehaviour {

    private Rigidbody rigidbody;
    public Vector3 torque;
    public float torqueTime;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        if(torqueTime >= 0f)
        {
            rigidbody.AddTorque(torque);
            torqueTime -= Time.deltaTime;
        }
    }
}

//newtons equivalent laws for rotaion
// with no net torque, angular velocity remains constant
//torque = inertia tensor * angular acceleration
//every torque has an equal and opposite torque