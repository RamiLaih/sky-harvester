using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    public Transform camera;
    public Transform target;
 
    void Update () 
    {
        camera.position = target.position + new Vector3(0, 10, -470);
    }

}
