using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour {

    private const float BigG = 6.674e-11f; //N·kg–2·m2   [m^3 s^-2 kg^-1]
    private PhysicsEngine[] physicsEngineArray;

    // Use this for initialization
    void Start () {
        physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        CalculateGravity();
    }
    void CalculateGravity()
    {
        foreach (PhysicsEngine physicsEngineA in physicsEngineArray)
        {
            foreach (PhysicsEngine physicsEngineB in physicsEngineArray)
            {
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2);

                    float gravitationalForce = BigG * (physicsEngineA.Mass * physicsEngineB.Mass / rSquared);
                    Vector3 gravitationalForceVector = gravitationalForce * offset.normalized;
                    Debug.Log("Calculating gravitational force of " + physicsEngineA + " by " + physicsEngineB);
                    physicsEngineA.AddForce(-gravitationalForceVector);
                }
            }
        }
    }
}
