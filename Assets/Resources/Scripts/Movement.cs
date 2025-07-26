using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.125f;
    public float jumpForce = 6f;
    public float sprintSpeed = 0.25f;
    public float groundCheck = 1.1f;
    public float soundCooldown = 1f;
    public float soundTimer = 0f;

    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 input;
    private bool onGround;

    public AudioSource walkSource;
    private AudioClip sound;

    private Material material;
    private int randomTile;
    public Vector3 move;
    public bool isMoving;

    public float minClimbHeight = 0.5f;
    public float maxClimbHeight = 2f;

    public float raycastMaxDist = 0.5f;

    public float climbSpeed = 1f;

    public float yOffset = 0.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        soundTimer += Time.deltaTime;
        
        
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            soundCooldown = 0.5f;
        }
        else
        {
            soundCooldown = 1f;
        }
        Moving();
        
        Crouching();
        //Jump
        onGround = Physics.Raycast(transform.position, Vector3.down, groundCheck, groundLayer);
        if (onGround)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheck))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                material = renderer.material;
                string materialName = renderer.material.name.Replace(" (Instance)", "");
                int randomTile = Random.Range(1, 10 + 1);
                if (materialName == "whitetilesfloor")
                {
                    
                    switch (randomTile)
                    {
                        case 1:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile1");
                            break;
                            case 2:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile2");
                            break;
                            case 3:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile3");
                            break;
                            case 4:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile4");
                            break;
                            case 5:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile5");
                            break;
                            case 6:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile6");
                            break;
                            case 7:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile7");
                            break;
                            case 8:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile8");
                            break;
                            case 9:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile9");
                            break;
                            case 10:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile10");
                            break;
                        /*default:
                            sound = Resources.Load<AudioClip>("SFX/player/footsteps/tile10");
                            break;*/
                    }

                    //Debug.Log("Sound " + sound + " loaded");
                }

            }
        }


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
            if (sound != null && soundTimer > soundCooldown)
            {
                
                    walkSource.PlayOneShot(sound);
                soundTimer = 0f;
                //Debug.Log("Sound " + sound + " played");
            }
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Climbable"))
        {
            //Debug.Log("Colliding");
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit climbHit, raycastMaxDist))
            {
                //Debug.LogWarning("Seeing " + climbHit.collider.name);

                if (isMoving)
                {
                    //Debug.Log("Moving");
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        //Debug.Log("Running");
                        if (Input.GetKey(KeyCode.Space))
                        {
                            //Debug.Log("Jumping");
                            if (collision.gameObject.CompareTag("Climbable") || collision.gameObject.CompareTag("Holdable"))
                            {
                                //Debug.Log("Colliding with " + collision.gameObject.name);
                                Bounds bounds = collision.collider.bounds;
                                float heightDiff = collision.collider.transform.position.y + transform.position.y;
                                //Debug.Log("Current heightDiff is " + heightDiff);
                                if (heightDiff >= minClimbHeight && heightDiff <= maxClimbHeight)
                                {
                                    //Debug.Log("Climbing");
                                    Vector3 forwardDir = Camera.main.transform.forward;
                                    forwardDir.y = 0;
                                    forwardDir.Normalize();
                                    Vector3 climbTarget = new Vector3(transform.position.x + forwardDir.x * 0.5f, bounds.max.y + yOffset, transform.position.z + forwardDir.z * 0.5f);
                                    //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, climbTarget, Time.deltaTime * climbSpeed);
                                    //print(climbTarget);
                                    StartCoroutine(ClimbTo(climbTarget));
                                    //insert playing sound

                                    IEnumerator ClimbTo(Vector3 targetPosition)
                                    {
                                        float elapsed = 0f;
                                        Vector3 start = transform.position;
                                        float duration = 1f;

                                        while (elapsed < duration)
                                        {
                                            transform.position = Vector3.Lerp(start, targetPosition, elapsed / duration);
                                            elapsed += Time.deltaTime;
                                            yield return null;
                                        }

                                        transform.position = targetPosition;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        
        
        
    }
    void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.56f, 0.5f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.85f, 0.5f);
        }
    }
}