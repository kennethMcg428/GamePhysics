using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour {

    public float magnusConstant = .1f;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.AddForce(magnusConstant* Vector3.Cross(rigidbody.angularVelocity, rigidbody.velocity));
	}
}
