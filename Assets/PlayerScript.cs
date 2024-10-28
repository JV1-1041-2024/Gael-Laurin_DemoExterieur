using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    public LayerMask layerMask;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 force = (transform.forward * forward * speed) + (transform.right * right * speed);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2f, layerMask))
        {
            force = Vector3.RotateTowards(force, hit.normal, 1, 1).normalized * speed;
            transform.position = new Vector3(transform.position.x,hit.point.y + 1,transform.position.z);
        }

        rb.AddForce(force);

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(new Vector3(0,jumpForce,0));

        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotation, 0);
    }
}
