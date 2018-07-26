using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class AddForce : MonoBehaviour {

    private PhysicsEngine phsx;
    public Vector3 forceVector; // [none]

	// Use this for initialization
	void Start () {
        phsx = GetComponent<PhysicsEngine>();
        
	}

    private void FixedUpdate()
    {
        phsx.AddForce(forceVector);
    }

}

