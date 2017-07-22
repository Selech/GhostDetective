using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public Transform Player;
    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public float Speed;
    private int CountDown;
    private bool started;

    public void PlayParticles()
    {
        GetComponent<ParticleSystem>().Play();
        CountDown = 150;
        started = true;
    }

    void OnParticleCollision(GameObject other)
    {
        print("Hit");
    }

    private void Update()
    {
        if(started)
            CountDown--;
    }

    void LateUpdate()
    {
        if (CountDown > 0)
            return;

        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, Player.position, Time.deltaTime * Speed);
        }

        // Apply the particle changes to the particle system
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }
}
