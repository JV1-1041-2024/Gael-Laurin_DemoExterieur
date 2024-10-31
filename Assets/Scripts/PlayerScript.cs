using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    public LayerMask layerMask;
    private int jumpBuffer = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpBuffer = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 force = (transform.forward * forward * speed) + (transform.right * right * speed);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2f, layerMask))
        {
            //force = Vector3.RotateTowards(force, hit.normal, 1, 1);
            if (rb.velocity.y <= 0) transform.position = new Vector3(transform.position.x,hit.point.y + 1,transform.position.z);
            if (jumpBuffer > 0) { rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z); jumpBuffer = 0; }
        }

        if (jumpBuffer > 0) jumpBuffer -= 1;

        rb.AddForce(force);

        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotation, 0);
    }
}
