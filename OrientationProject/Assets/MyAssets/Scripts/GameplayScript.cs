using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
public class GameplayScript : MonoBehaviour
{
    [SerializeField]
    public Teleport Teleporting;
    public Material currentColorMaterial;
    //[SerializeField]
    //private Material teleportArcMaterial;
    Color currrentColor;

    // Start is called before the first frame update
        void Start()
        {
            currrentColor = currentColorMaterial.GetColor("_TintColor");
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Teleporting.areaHighlightedMaterial.SetColor("_TintColor", currrentColor);
            Teleporting.pointerValidColor = currrentColor;
            //teleportArcMaterial.SetColor("tintColor", currrentColor); 
        }
    }
}