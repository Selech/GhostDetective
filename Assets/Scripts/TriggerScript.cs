using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<InteractableObject>().Complete();
    }
}