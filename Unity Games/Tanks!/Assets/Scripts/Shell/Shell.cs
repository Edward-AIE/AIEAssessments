using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    //Time in seconds before shell is removed
    public float m_MaxLifeTime = 2f;
    //Amount of damage done if explosion is centred on a tank
    public float m_MaxDamage = 34f;
    //The maximum distacne away from the explosion a tank can be and still be affected
    public float m_ExplosionRadius = 5;
    //The amount of force added to a tank at the centre of the explosion
    public float m_ExplosionForce = 100f;

    //Reference to the particles that will play on explosion
    public ParticleSystem m_ExplosionParticles;
    
    //Use this for initialisation
    void Start()
    {
        //If it isn't destroyed by then, destroy the shell after its lifetime
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Find the rigidbody of the collision object
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

        //
        // TO DO: Add code hre to damage the object (tank) we just collided with
        //

        //Unparent the particles from the shell
        m_ExplosionParticles.transform.parent = null;

        //Play the particle system
        m_ExplosionParticles.Play();

        //Once the particles have fiished, destroy the gameObject they are on
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        //Destroy the shell
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
