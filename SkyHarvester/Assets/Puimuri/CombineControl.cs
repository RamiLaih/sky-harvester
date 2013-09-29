using UnityEngine;
using System.Collections;

public class CombineControl : MonoBehaviour {

    public WheelCollider rearWheel;
    public WheelCollider frontWheel;
    public Transform frontWheelTransform;
    public Transform rearWheelTransform;

	public float maxTorque = 50F;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rearWheel.motorTorque = -maxTorque;
            frontWheel.motorTorque = -maxTorque;
        }
		else if (Input.GetKey(KeyCode.UpArrow))
        {
            rearWheel.motorTorque = maxTorque;
            frontWheel.motorTorque = maxTorque;
        }
		else {
			rearWheel.motorTorque = 0;
			frontWheel.motorTorque = 0;
		}
		
	}

    void Update()
    {
        frontWheelTransform.Rotate( 0, 0, -frontWheel.rpm / 60F * 360F * Time.deltaTime);
        rearWheelTransform.Rotate( 0, 0, -rearWheel.rpm / 60F * 360F * Time.deltaTime);
    }
}
