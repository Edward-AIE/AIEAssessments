using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashToEnemy : MonoBehaviour
{
    [SerializeField] private KeyCode dashKey = KeyCode.Mouse1;
    private float airDashForceMulti = 2;
    private float groundDashForceMulti = 7;
    public LayerMask enemy;
    private RaycastHit hitInfo;
    private Transform enemyDashSpot;
    private Rigidbody rb;
    private Camera cam;
    private Enemy temp;
    private PlayerMovement player;
    private bool canDash;
    private float dashForce;

    private Vector3 direction;
    private float distance;

    private void Start()
    {
        canDash = false;
        
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDashSpot != null)
        {
            direction = (enemyDashSpot.position - transform.position).normalized;
            distance = Vector3.Distance(enemyDashSpot.position, transform.position);

            if (player.isGrounded)
            {
                dashForce = distance * groundDashForceMulti;
            }
            else if (!player.isGrounded)
            {
                dashForce = distance * airDashForceMulti;
            }
        }
        
        if (canDash)
        {
            if (Input.GetKeyDown(dashKey))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(direction * dashForce, ForceMode.Impulse);
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
