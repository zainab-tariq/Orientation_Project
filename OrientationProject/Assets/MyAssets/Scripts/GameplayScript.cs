using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
public class GameplayScript : MonoBehaviour
{
    [SerializeField]
    private Teleport Teleporting;
    [SerializeField]
    public Material teleportPointerMaterial;
    public Material currentColorMaterial;

    //[SerializeField]
    //private Material teleportArcMaterial;
    Color currrentColor;

    // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            currrentColor = currentColorMaterial.GetColor("_TintColor");
            Teleporting.areaHighlightedMaterial.SetColor("_TintColor", currrentColor);
            Teleporting.pointerValidColor = currrentColor;
            teleportPointerMaterial.SetColor("_TintColor", currrentColor);
            Teleporting.pointHighlightedMaterial.SetColor("_TintColor", currrentColor);
            //teleportArcMaterial.SetColor("tintColor", currrentColor); 
        }
    }
}