using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public BoxCollider triggerCollider;
    public BoxCollider touchCollider;

    public void Activate()
    {
        triggerCollider.gameObject.SetActive(true);
        touchCollider.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        triggerCollider.gameObject.SetActive(false);
        touchCollider.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Complete();
    }

    public void Complete()
    {
        // Ryk ud som Start()
        Deactivate();
        GameObject.Find("MainCanvas").GetComponent<ClueCanvasController>().CompletePuzzle();
    }
}
