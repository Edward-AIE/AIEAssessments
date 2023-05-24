using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashToEnemy : MonoBehaviour
{
    private Image dashConfirm;
    private bool canDash;
    [SerializeField] private float dashTime;
    [SerializeField] private KeyCode dashKey = KeyCode.Mouse1;
    [SerializeField] private Transform orientation;

    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            if (Input.GetKeyDown(dashKey))
            {
                Debug.Log("Dash");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy temp = other.GetComponent<Enemy>();

            if(temp != null)
            {
                Transform enemyDashSpot = temp.GetDashPosition();
                dashConfirm = temp.GetImage();


                if (Physics.Raycast(orientation.position, orientation.forward, Mathf.Infinity))
                {
                    dashConfirm.enabled = true;
                    canDash = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            dashConfirm.enabled = false;
            canDash = false;
        }
    }
}
