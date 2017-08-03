using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class InputController : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent agent;
    [Tooltip("Layers used for touchable items the NavMesh agent should navigate to.")]
    public LayerMask touchableLayers;

    void Start()
    {
        agent = Player.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray, Mathf.Infinity, touchableLayers);

        if (hits.Length > 0)
        {
            var hit = hits.First();

            if(hit.collider.gameObject.tag == "ClickableObject"){
                agent.SetDestination(hit.collider.gameObject.transform.parent.position);
            }
            else if(hit.collider.gameObject.tag == "Door"){
				agent.SetDestination(hit.collider.gameObject.GetComponent<DoorScript>().GetPosition());
            }

        }
    }
}
