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
        //Find the rigidbody of the collision object
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
        
        //Only tanks will have rigidbody scripts
        if (targetRigidbody != null)
        {
         
            //Add an explosion force
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            //Find the TankHealth script associated with the rigidbody
          
        }

        TankHealth targetHealth = other.gameObject.GetComponent<TankHealth>();
        
        if (targetHealth != null)
        {
            //Calculate the amoutn of damage the target should take based on its distance from the shell
            float damage = CalculateDamage(targetHealth.transform.position);

            //Deal this damage to the tank
            targetHealth.TakeDamage(damage);
        }

        //Unparent the particles from the shell
        m_ExplosionParticles.transform.parent = null;

        //Play the particle system
        m_ExplosionParticles.Play();

        //Once the particles have fiished, destroy the gameObject they are on
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        //Destroy the shell
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        //Create a vector from the shell to the target
        Vector3 explosionToTarget = targetPosition - transform.position;

        //Calculate the distance from the shell to the target
        float explosionDistance = explosionToTarget.magnitude;
      
        //Calculate the proportion of the maximum distance (the explosionRadius) the target is away
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_MaxDamage;
       
        //Calculate damage as this proportion of the maximum possible damage
        float damage = relativeDistance * m_MaxDamage;

        //Make sure that the minimum damage is always 0
        damage = Mathf.Max(0f, damage);

        return damage; 
    }
}
