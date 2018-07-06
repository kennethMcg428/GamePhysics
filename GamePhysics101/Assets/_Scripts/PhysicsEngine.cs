using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {

    public Vector3 VelocityVector; // average velocity this FixedUpdate()


	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        Accelerate();
    }
    void Accelerate()
    {
        transform.position += VelocityVector * Time.deltaTime;
    }
}
