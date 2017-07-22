using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueScript : MonoBehaviour {

    private Animation anim;
    private ClueCanvasController controller;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animation>();
    }   
	
    void OnEnable()
    {
        anim.Play("FadeIn"); 
    }

    public void Clicked()
    {
        anim.Play("FadeOut");
    }

    public void DisableGameObject() {
        gameObject.SetActive(false);      
    }
}
