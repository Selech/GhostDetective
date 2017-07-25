using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSmokeRandonmizer : MonoBehaviour {

    private int countdown;
    private Animator anim;
    private ParticleSystem ps;

    // Use this for initialization
    void Start () {
        countdown = Random.Range(90,250);
        anim = GetComponent<Animator>();
        ps = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        countdown--;

        if (countdown <= 0)
            PlaySmoke();
	}

    public void PlaySmoke()
    {
        countdown = Random.Range(90, 250);
        anim.SetTrigger("Smoke");
    }

    public void StartParticle()
    {
        ps.Play();
    }
}
