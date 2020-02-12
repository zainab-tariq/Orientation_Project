using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    // Use this for initialization

    public Transform target;
    public float orbitDistance = 2.0f;
    public float orbitDegreesPerSec = 180.0f;
    public Vector3 relativeDistance = Vector3.zero;
    public bool once = true;
    // Use this for initialization
    void Start()
    {
        //Orbit at start 
        if (target != null)
        {
            relativeDistance = transform.position - target.position;
        }
    }

    void Orbit()
    {

        // to do: orbitDistance random between two vales
        // relativeDistance A-axis random between 2 values 
        // set orbit speed

        if (target != null)
        {
            // Keep us at the last known relative position
            transform.position = (target.position + relativeDistance);
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
            // Reset relative position after rotate
            if (once)
            {
                transform.position *= orbitDistance;
                once = false;
            }
            relativeDistance = transform.position - target.position;
        }
    }

    void LateUpdate()
    {

        Orbit();

    }
}
