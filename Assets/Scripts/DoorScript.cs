using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Transform PositionOut;
    public Transform PositionIn;

    private bool GoingOut = true;

    public Vector3 GetPosition()
    {
        return GoingOut ? PositionOut.position : PositionIn.position;
    }

    void OnTriggerEnter(Collider other)
    {
        GoingOut = !GoingOut;
    }
}
