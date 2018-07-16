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
    //Trails
    public bool showTrails = true;
    private LineRenderer lineRenderer;
    private int numberOfForces;

    //Force Vectors
    private Vector3 FrictionalForce;
    private Vector3 GravitationalForce;
    private Vector3 AppliedForce;
    private Vector3 NormalForce;
    private Vector3 AirResistanceForce;
    private Vector3 SpringForce;
    public Vector3 netForceVector;

    public List<Vector3> forceVectorList = new List<Vector3>();
    public Vector3 VelocityVector; // average velocity this FixedUpdate()


    public float Mass = 1;

	// Use this for initialization
	void Start () {
        InitializeTrails();
	}
    private void Update()
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
    private void FixedUpdate()
    {
        AddForces();
        UpdateVelocity();
        transform.position += VelocityVector * Time.deltaTime;
    }
    void Accelerate()
    {
           UpdateVelocity();
          
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
        VelocityVector += accelerationVector * Time.deltaTime;
    }
    void InitializeTrails()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(Color.yellow, Color.yellow);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.useWorldSpace = false;
    }
    public List<Vector3> GetForceVectorList()
    {
        return forceVectorList;
    }
}
