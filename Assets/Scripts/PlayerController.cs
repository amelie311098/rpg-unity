using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private float speed_rotation = 20f;
    private Rigidbody rigidbody;

    Commands commands;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        commands = Utils.GetCommandConfig();
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

        if (Input.GetKey(commands.UpArrow))
        {
            // forward
            relative += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(commands.LeftArrow))
        {
            // left
            relative += transform.right * -1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(commands.DownArrow))
        {
            // backward
            relative += transform.forward * -1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(commands.RightArrow))
        {
            // right
            relative += transform.right * speed * Time.deltaTime;
        }

        rigidbody.MovePosition(rigidbody.position + relative);
    }

    private void Turn()
    {
        float direction = 0;
        if (Input.GetKey(commands.RotateLeft))
        {
            direction = -1;
        }
        if (Input.GetKey(commands.RotateRight))
        {
            direction = 1;
        }
        float turn = direction * speed_rotation * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turn, 0);
        rigidbody.MoveRotation(rigidbody.rotation * rotation);
    }
}
