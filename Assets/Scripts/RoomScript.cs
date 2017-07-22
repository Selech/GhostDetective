using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

    [Header("Camera settings")]
    public float Size;
    public Vector3 Position;

    [Header("Wall settings")]
    public WallScript[] Walls;
    public WallController Controller;

    private void OnTriggerEnter(Collider other)
    {
        Controller.ChangeWalls(Walls, Position, Size);
    }


    //private void OnTriggerExit(Collider other)
    //{
    //    foreach (var mesh in Walls)
    //    {
    //        mesh.sharedMaterial = RawWalls;
    //    }
    //}

}
