using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public WallScript[] Walls;
    public CinemachineVirtualCamera[] VirtualCameras;

    public CamController CamController;

    public void ChangeWalls(WallScript[] fadedWalls, Vector3 targetPos, float targetSize) { 
        foreach(var wall in Walls)
        {
            wall.ShowWall();
        }

        foreach (var wall in fadedWalls)
        {
            wall.FadeWall();
        }

        CamController.SetPosition(targetPos);
        CamController.TargetSize = targetSize;
    }

    public void ChangeWalls(WallScript[] fadedWalls, CinemachineVirtualCamera activeCam)
    {
        foreach (var wall in Walls)
        {
            wall.ShowWall();
        }

        foreach (var wall in fadedWalls)
        {
            wall.FadeWall();
        }

        foreach (var cam in VirtualCameras)
        {
            cam.gameObject.SetActive(false);
        }

        activeCam.gameObject.SetActive(true);
    }
}
