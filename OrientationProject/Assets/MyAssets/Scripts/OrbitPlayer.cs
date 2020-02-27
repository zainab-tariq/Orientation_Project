using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public Transform target;
    public float sphereTranslateSpeed = 1.0f;
    public float orbitDistance = 2.0f;
    public float orbitDegreesPerSec = 180.0f;
    public Vector3 relativeDistance = Vector3.zero;
    public float yPosition = 0;

    void Start()
    {
         if (target != null)
        {
            //// to do translate the spehre to the orbit position 
            //// example: transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * sphereTranslateSpeed);
            // orbit around target gameObject 
            //relativeDistance = transform.position - target.position;
            relativeDistance = new Vector3(transform.position.x - target.position.x, yPosition, transform.position.z - target.position.z);
            
        }
        
    }

    void Orbit()
    {
        if (target != null)
        {
            // Keep us at the last known relative position
            transform.position = (target.position + relativeDistance);
            //rotate
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
            //reset relative position after rotate
            relativeDistance = new Vector3(transform.position.x - target.position.x, yPosition, transform.position.z - target.position.z);
            //relativeDistance = transform.position - target.position;
            //gradualy move with the player and still orbit
            transform.position = Vector3.MoveTowards(transform.position, relativeDistance, Time.deltaTime * sphereTranslateSpeed);
        }
    }

    void LateUpdate()
    {
        Orbit();

    }
}
