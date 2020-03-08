using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public GameObject targetGO;
    private Transform target;
    public float sphereTranslateSpeed = 1.0f;
    public float orbitDistance = 2.0f;
    public float orbitDegreesPerSec = 180.0f;
    private Vector3 relativeDistance = Vector3.zero;
    private Vector3 playerPosition;
    public float yPosition = 0;

    void Start(){
        targetGO = GameObject.Find("/Player/NoSteamVRFallbackObjects/FallbackObjects"); //player position for no VR
        //targetGO = GameObject.Find("/Player/SteamVRObjects"); // player position for VR
    }



    void Orbit()
    {
        if(target != null)
            {
                Vector3 targetPosition = new Vector3(target.position.x, yPosition, target.position.z);
                Vector3 transformPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
                // Keep us at orbitDistance from target
                transform.position = targetPosition + (transformPosition - targetPosition).normalized * orbitDistance;
                transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
            }
    }

    void LateUpdate()
    {
        target = targetGO.transform;
            //Orbit();
            
        if (transform.position.z >= target.position.z - orbitDistance)
        {
            Orbit();
        }
        else
        {
            playerPosition = new Vector3(target.position.x , yPosition, target.position.z + orbitDistance); // current player position update in case player moves
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * sphereTranslateSpeed);
        }
        
    }
}
