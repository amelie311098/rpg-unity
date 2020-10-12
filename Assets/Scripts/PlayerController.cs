using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private float speed_rotation = 20f;
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
            relative += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            // left
            relative += transform.right * -1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            // backward
            relative += transform.forward * -1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            // right
            relative += transform.right * speed * Time.deltaTime;
        }

        rigidbody.MovePosition(rigidbody.position + relative);
    }

    private void Turn()
    {
        float direction = 0;
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        float turn = direction * speed_rotation * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turn, 0);
        rigidbody.MoveRotation(rigidbody.rotation * rotation);
    }
}
