using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashToEnemy : MonoBehaviour
{
    private bool canDash;
    [SerializeField] private float dashTime;
    [SerializeField] private KeyCode dashKey = KeyCode.Mouse1;
    [SerializeField] private Transform cameraPosition;
    public LayerMask enemy;
    private RaycastHit hitInfo;
    private Transform enemyDashSpot;
    private Camera cam;
    private Enemy temp;

    private void Start()
    {
        canDash = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            if (Input.GetKeyDown(dashKey))
            {
                Debug.Log("Dash");
                // Add dashing functionality
            }
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, 20f, enemy))
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                temp = hitInfo.collider.GetComponent<Enemy>();

                if (temp != null)
                {
                    enemyDashSpot = temp.GetDashPosition();

                    canDash = true;
                    temp.ImageOn();
                }
            }
            else
            {
                NoDash();
            }
        }
        else
        {
            NoDash();
        }
    }

    private void NoDash()
    {
        temp.ImageOff();
        canDash = false;
    }
}
