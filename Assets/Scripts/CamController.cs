using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform Player;

    Vector3 TargetPosition = new Vector3(10, 10, -10);
    [HideInInspector]
    public float TargetSize = 3.5f;
    private Camera cam;

    // Panning stuff
    private Vector3 StartTilt;
    private Vector3 panning;
    private float PanningSpeed = 2f;
    private float offset = 0.1f;
    private float panningLimit = 3f; 

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // TODO
        StartTilt = Input.acceleration;

        cam = GetComponent<Camera>();
    }

    public void SetPosition(Vector3 target)
    {
        panning = Vector3.zero;
        TargetPosition = target;
    }

    // Update is called once per frame
    void Update()
    {
        // var from = Player.position + new Vector3(5, 4, -5);

        if (Input.acceleration.z < StartTilt.z + offset && panning.x > -panningLimit && panning.z < panningLimit)
        { panning += new Vector3(Input.acceleration.z- StartTilt.z, 0, -Input.acceleration.z+ StartTilt.z) * PanningSpeed; } // up

        if (Input.acceleration.z > StartTilt.z - offset && panning.x < panningLimit && panning.z > -panningLimit)
        { panning += new Vector3(-Input.acceleration.z - StartTilt.z, 0, Input.acceleration.z + StartTilt.z) * PanningSpeed; } // down

        if (Input.acceleration.x >  offset && panning.x < panningLimit && panning.z < panningLimit)
        { panning += new Vector3(Input.acceleration.x, 0, Input.acceleration.x) * PanningSpeed; } // right

        if (Input.acceleration.x < - offset && panning.x > -panningLimit && panning.z > -panningLimit)
        { panning += new Vector3(Input.acceleration.x, 0, Input.acceleration.x) * PanningSpeed; } // left


        var targetPosition = TargetPosition;// + panning;

        transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * 2);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, TargetSize, Time.deltaTime * 2);

        return;
    }
}
