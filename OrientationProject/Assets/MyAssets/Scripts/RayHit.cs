using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHit : MonoBehaviour
{
    LineRenderer laserLine;

    [SerializeField] GameObject child;
    public float minRadialDistance = 1;
    public float maxRadialDistance = 25;

    void start() {
        laserLine = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        laserLine = gameObject.GetComponent<LineRenderer>();
        RaycastHit hitInfo;
        laserLine.SetPosition(0, transform.position);

        Physics.Linecast(transform.position,
                        transform.position + transform.forward * maxRadialDistance,
                         out hitInfo);

        if (hitInfo.collider)
        {
            laserLine.SetPosition(1, hitInfo.point);
            child.SetActive(true);
            child.transform.position = hitInfo.point; //new Vector3(rhit.point.x, rhit.point.y, transform.position.z);
        }
        else
        {
            //laserLine.SetPosition(1, transform.position + transform.forward * 100.0f);
            child.SetActive(false);
        }
    }
}
