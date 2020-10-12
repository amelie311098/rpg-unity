using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 relative = Vector3.zero;

        if (Input.GetKey(KeyCode.I))
        {
            // forward
            relative += transform.InverseTransformDirection(Vector3.forward).normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            // left
            relative += transform.InverseTransformDirection(Vector3.left).normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            // backward
            relative += transform.InverseTransformDirection(Vector3.back).normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            // right
            relative += transform.InverseTransformDirection(Vector3.right).normalized * speed * Time.deltaTime;
        }

        rigidbody.MovePosition(transform.position + relative);
    }

    private void Turn()
    {

    }
}
