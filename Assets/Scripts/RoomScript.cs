using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

    //[Header("Camera settings old")]
    //public float Size;
    //public Vector3 Position;

    [Header("Camera settings")]
    public CinemachineVirtualCamera Camera; 

    [Header("Wall settings")]
    public WallScript[] Walls;
    public WallController Controller;

    private void OnTriggerEnter(Collider other)
    {
        Controller.ChangeWalls(Walls, Camera);
    }


    //private void OnTriggerExit(Collider other)
    //{
    //    foreach (var mesh in Walls)
    //    {
    //        mesh.sharedMaterial = RawWalls;
    //    }
    //}

}
