using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {

    //Forces

    /*
Frictional Force*
Gravitational Force*
Tension Force*
Electrical Force
Normal Force*
Magnetic Force
Air Resistance Force* 
Applied Force*
Spring Force*
         */
         //Force Vectors
    private Vector3 FrictionalForce;
    private Vector3 GravitationalForce;
    private Vector3 AppliedForce;
    private Vector3 NormalForce;
    private Vector3 AirResistanceForce;
    private Vector3 SpringForce;
    private Vector3 netForceVector;

    public List<Vector3> forceVectorList = new List<Vector3>();
    public Vector3 VelocityVector; // average velocity this FixedUpdate()


    public float Mass = 1;

	// Use this for initialization
	void Start () {
       FrictionalForce.x = 5;
       //forceVectorList.Add(FrictionalForce);
        
	}

    private void FixedUpdate()
    {
        AddForces();
        Accelerate();
    }
    void Accelerate()
    {
        if(netForceVector == Vector3.zero)
        {
            transform.position += VelocityVector * Time.deltaTime;
        }
        else
        {
            UpdateVelocity();
            transform.position += VelocityVector * Time.deltaTime;
        }
        
    }
    void AddForces()
    {
        netForceVector = Vector3.zero;
        foreach(Vector3 forceVector in forceVectorList)
            { netForceVector += forceVector; }
    }
    void UpdateVelocity()
    {
        Vector3 accelerationVector = netForceVector / Mass;
        VelocityVector = accelerationVector * Time.deltaTime;
    }
}
