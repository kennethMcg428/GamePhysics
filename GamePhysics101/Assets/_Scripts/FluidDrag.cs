using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour {

[Range(1, 2)]
public float velocityExponent;

public float dragConstant;

    private PhysicsEngine physx;

	// Use this for initialization
	void Start () {
        physx = GetComponent<PhysicsEngine>();
	}
	
	// Update is called once per frame

    private void FixedUpdate()
    {
        Vector3 velocityVector = physx.VelocityVector;
        float speed = velocityVector.magnitude;
        float dragSize = CalculateDrag(speed);
        Vector3 dragVector = dragSize * -velocityVector.normalized;
        physx.AddForce(dragVector);
    }
    float CalculateDrag(float velocity)
    {
        return dragConstant * Mathf.Pow(velocity, velocityExponent);

    }
}
