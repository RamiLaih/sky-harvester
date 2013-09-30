using UnityEngine;
using System.Collections;

public class ThrusterControl : MonoBehaviour {

	public Rigidbody rearThruster;
    public ParticleSystem rearParticles;
	public Rigidbody frontThruster;
    public ParticleSystem frontParticles;

    public float rearForce = 5000;
    public float frontForce = 5000;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rearThruster.AddForce(rearThruster.transform.up * rearForce);
            rearParticles.enableEmission = true;
            Debug.Log("rear");
        }
        else
        {
            rearParticles.enableEmission = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frontThruster.AddForce(frontThruster.transform.up * frontForce);
            Debug.Log("front");
            frontParticles.enableEmission = true;
        }
        else
        {
            frontParticles.enableEmission = false;
        }
	}
}
