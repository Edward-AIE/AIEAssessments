using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulateLight : MonoBehaviour
{
    [SerializeField] Light pointLight;
    [SerializeField] Material lightMat;

    private void Start()
    {
        pointLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pointLight.enabled = true;
            lightMat.SetColor("_Colour", Color.white);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pointLight.enabled = false;
            lightMat.SetColor("_Colour", Color.black);
        }
    }
}
