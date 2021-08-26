using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Joystick joystick;

    private float zMovement;
    private float xMovement;

    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = joystick.Horizontal;
        zMovement = joystick.Vertical;

        rb.AddRelativeForce(new Vector3(xMovement, 0, zMovement) * speed);

    }
    private void FixedUpdate()
    {
        Debug.Log(new Vector3(xMovement, 0, zMovement) * speed);
    }
}
