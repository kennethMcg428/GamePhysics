using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

    public float fuelMass;          // [kg]
    public float maxThrust;         // kN [kg m s^-2]

    [Range(0,1)]
    public float thrustPercent;     // [none]

    private PhysicsEngine phsx;     
    public Vector3 ThrustUnitVector;// [none]

    private float currTrust;        // N

    // Use this for initialization
    void Start()
    {
        phsx = GetComponent<PhysicsEngine>();
        phsx.Mass += fuelMass;
    }

    private void FixedUpdate()
    {
        if(fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            phsx.Mass -= FuelThisUpdate();
            ExertForce();
        }
        else
        {
            Debug.LogWarning("out of fuel");
        }
    }

    float FuelThisUpdate()
    {
        float exhaustMassFlow = 0 ;
        float effectiveExhaustVelocity = 0;

        effectiveExhaustVelocity = 4464;            // [m s^=1]     liquid H O

        //effectiveExhaustVelocity = 4535;            //  [m s^-1]  LH2

        exhaustMassFlow = currTrust / effectiveExhaustVelocity;

        return exhaustMassFlow * Time.deltaTime;
    }
    void ExertForce()
    {
        currTrust = thrustPercent * maxThrust * 1000;
        Vector3 thrustVector = ThrustUnitVector.normalized * currTrust;
        phsx.AddForce(thrustVector);
        
    }
}
