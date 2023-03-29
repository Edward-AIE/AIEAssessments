using UnityEngine;
using System.Collections;
public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;
    public Transform m_target;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;
    private float scroll;

    private void Awake()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Zoom();
    }
    private void Move()
    {
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
    private void Zoom()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (Camera.main.orthographicSize > 0)
            {
                Camera.main.orthographicSize += scroll;
            }
        }
    }
}