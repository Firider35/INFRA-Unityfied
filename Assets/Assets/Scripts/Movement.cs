using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.125f;
    public float jumpForce = 6f;
    public float sprintSpeed = 0.25f;
    public float groundCheck = 1.1f;

    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 input;
    private bool onGround;


    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


        Moving();

        //Jump
        onGround = Physics.Raycast(transform.position, Vector3.down, groundCheck, groundLayer);
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.C) && moveSpeed == 0.125f)
        {
            moveSpeed = 0;
        }
        else if (Input.GetKeyDown(KeyCode.C) && moveSpeed == 0f)
        {
            moveSpeed = 0.125f;
        }
    }
    void Moving()
    {
       
        
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
            float moveForward = Input.GetAxis("Vertical") * currentSpeed;
            float strafe = Input.GetAxis("Horizontal") * currentSpeed;

            Vector3 move = transform.forward * moveForward + transform.right * strafe;

            if (move.magnitude > 0)
            {
                rb.MovePosition(rb.position + move * moveSpeed);
            }

    }

}