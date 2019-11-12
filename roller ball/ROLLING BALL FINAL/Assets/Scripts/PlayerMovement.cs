using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forward;
    public float horizontal = 10f;
    public float vertical = 10f;
    public float up = 4f;
    protected bool jump;
    protected Joystick joystick;
    protected joybutton joybutton;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0f, 0f, forward);
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * horizontal,
            rigidbody.velocity.y, joystick.Vertical * vertical);

        if (!jump && joybutton.Pressed)
        {
            jump = true;
            rigidbody.velocity += Vector3.up * up;
        }
        if (jump && !joybutton.Pressed)
        {
            jump = false;

        }
    }
}
