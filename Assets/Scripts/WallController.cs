using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    public WallScript[] Walls;

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
}
