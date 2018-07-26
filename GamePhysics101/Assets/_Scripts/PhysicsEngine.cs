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
    
    private int numberOfForces;

    //Force Vectors
   // private Vector3 FrictionalForce;
   // private Vector3 GravitationalForce;
   // private Vector3 AppliedForce;
   // private Vector3 NormalForce;
   // private Vector3 AirResistanceForce;
   // private Vector3 SpringForce;

    [HideInInspector]
    public List<Vector3> forceVectorList = new List<Vector3>();

    private PhysicsEngine[] physicsEngineArray;
    public float Mass = 1;      // [kg]
    public Vector3 VelocityVector; // [m s^-1]
    public Vector3 netForceVector; // N [kg m s^-1]
     //Trails
    private LineRenderer lineRenderer;
    public bool showTrails = true;

    private const float BigG = 6.674e-11f; //N·kg–2·m2   [m^3 s^-2 kg^-1]

    // Use this for initialization
    void Start () {
        InitializeTrails();
        physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
	}
    void CalculateGravity()
    {
        foreach(PhysicsEngine physicsEngineA in physicsEngineArray)
        {
            foreach(PhysicsEngine physicsEngineB in physicsEngineArray)
            {
                if(physicsEngineA != physicsEngineB)
                {
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2);
               
                    float gravitationalForce = BigG*(physicsEngineA.Mass * physicsEngineB.Mass /rSquared);
                    Vector3 gravitationalForceVector = gravitationalForce * offset.normalized;
                    Debug.Log("Calculating gravitational force of " + physicsEngineA + " by " + physicsEngineB);
                    physicsEngineA.AddForce(-gravitationalForceVector);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        RenderTrails();
        CalculateGravity();
        UpdatePosition();
    }

    public void AddForce(Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
    }

    void UpdatePosition()
    {
        //Sum forces add clear list
        netForceVector = Vector3.zero;
        foreach(Vector3 forceVector in forceVectorList)
            { netForceVector += forceVector; }
        forceVectorList = new List<Vector3>();
        // Calculate change in acceleration and velocity due to change in net force
        Vector3 accelerationVector = netForceVector / Mass;
        VelocityVector += accelerationVector * Time.deltaTime;
        //Update position
        transform.position += VelocityVector * Time.deltaTime;
    }

    void InitializeTrails()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(Color.yellow, Color.yellow);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.useWorldSpace = false;
    }

    private void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.SetVertexCount(numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
