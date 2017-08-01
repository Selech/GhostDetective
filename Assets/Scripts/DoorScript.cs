using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Transform PositionOut;
    public Transform PositionIn;

    private bool GoingOut = false;

    public Vector3 GetPosition()
    {
        GoingOut = !GoingOut;
        return GoingOut ? PositionOut.position : PositionIn.position;
    }

}
