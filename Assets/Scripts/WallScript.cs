using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    private Material[] materials;
    public Material[] FadedWallMaterial;
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materials = meshRenderer.sharedMaterials;
    }

    public void FadeWall()
    {
        meshRenderer.sharedMaterials = FadedWallMaterial;

    }

    public void ShowWall()
    {
        meshRenderer.sharedMaterials = materials;
    }

}
