using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public float LaunchSpeed;
    public float MaxLaunchSpeed;
    public GameObject Projectile;
    public Transform direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnMouseDown()
    {

        InvokeRepeating("IncreaseSpeed", Time.deltaTime,Time.deltaTime);
       
    }
    private void OnMouseUp()
    {
        if(LaunchSpeed > 0)
        {
            CancelInvoke("IncreaseSpeed");
            GameObject currProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            Vector3 LaunchForce = new Vector3(-1,1,0).normalized * LaunchSpeed;
            currProjectile.GetComponent<PhysicsEngine>().AddForce(LaunchForce);
            Debug.Log("Launching ball");
            
        }
       LaunchSpeed = 0;
    }
    void IncreaseSpeed()
    {
        if (LaunchSpeed < MaxLaunchSpeed)
        {
            LaunchSpeed += 10;
            Debug.Log("mouse Dowm launch speed increased to " + LaunchSpeed); 
        }
      
    }
}
