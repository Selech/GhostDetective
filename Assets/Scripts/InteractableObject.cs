using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    private BoxCollider activationCollider;

    public void Activate()
    {
        activationCollider = GetComponentInChildren<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    public void Complete()
    {

    }
}
