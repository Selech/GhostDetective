using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    public BoxCollider triggerCollider;
    public BoxCollider touchCollider;

    public void Activate()
    {
        triggerCollider.gameObject.SetActive(true);
        touchCollider.gameObject.SetActive(true);
	}

    void OnTriggerEnter(Collider other)
    {
        Complete();
    }

    public void Complete()
    {
        // Ryk ud som Start()
        GameObject.Find("MainCanvas").GetComponent<ClueCanvasController>().CompletePuzzle();
    }
}
