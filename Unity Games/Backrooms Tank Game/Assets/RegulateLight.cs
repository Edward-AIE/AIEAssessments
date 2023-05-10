using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulateLight : MonoBehaviour
{
    [SerializeField] Light pointLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pointLight.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pointLight.enabled = false;
        }
    }
}
