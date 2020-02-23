using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameplayScript : MonoBehaviour
{
    [SerializeField]
    private Material teleportAreaHighlight;
    [SerializeField]
    private Material currentColorMaterial;
    [SerializeField]
    private Material teleportArcMaterial;
    Color currrentColor;

    // Start is called before the first frame update
    void Start()
    {
        currrentColor = currentColorMaterial.GetColor("TintColor");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        teleportAreaHighlight.SetColor("tintColor", currrentColor);
        teleportArcMaterial.SetColor("tintColor", currrentColor);
    }
}
