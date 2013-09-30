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
        manageSuspensionAndRotation(frontWheel, frontWheelTransform);
        manageSuspensionAndRotation(rearWheel, rearWheelTransform);
    }

    void manageSuspensionAndRotation(WheelCollider collider, Transform transform)
    {
        transform.Rotate(0, 0, -collider.rpm / 60F * 360F * Time.deltaTime);

        RaycastHit hit;

        Vector3 colliderCenter = collider.transform.TransformPoint(collider.center);
        Vector3 colliderDirection = collider.transform.TransformDirection(-collider.transform.up);

        if (Physics.Raycast(colliderCenter, colliderDirection, out hit, collider.suspensionDistance + collider.radius))
        {
            transform.position = hit.point - colliderDirection * collider.radius;
        }
        else
        {
            transform.position = colliderCenter - collider.transform.up * collider.suspensionDistance;
        }
    }

}
