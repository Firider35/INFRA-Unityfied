using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform anchor;
    public int maxRaycastDist = 5;
    public float sphereRadius = 1f;
    public bool isHoldingObject;

    public bool Act1;
    public bool Act2;
    public bool Act3;
    public GeocacheDetector geoDetector; //the hell is this doing here


    private GameObject heldObject;
    private Rigidbody heldRb;

    public float forceAmount = 5f;

    RaycastHit hit;
    RaycastHit hitray;
    RaycastHit validhit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                isHoldingObject = false;
                heldRb.useGravity = true;
                heldRb.constraints = RigidbodyConstraints.None;

                heldObject = null;
                heldRb = null;
                
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool sphereHit = Physics.SphereCast(ray, sphereRadius, out hit, maxRaycastDist);
            bool rayHit = Physics.Raycast(ray, out hitray, maxRaycastDist);

            if (sphereHit || rayHit)
            {
                //Debug.Log("Hit" + hit.collider.gameObject.name);
                //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);
                if (sphereHit)
                {
                    validhit = hit;
                }
                else
                {
                    validhit = hitray;
                }
                GameObject hitObject = validhit.collider.gameObject;
                if (hitObject.CompareTag("Holdable"))
                {


                    heldObject = hitObject;
                     heldRb = heldObject.GetComponent<Rigidbody>();
                     /*if (heldRb == null)
                    {
                        heldRb = heldObject.transform.parent.GetComponent<Rigidbody>();
                    }*/
                     heldRb.useGravity = false;
                     heldRb.constraints = RigidbodyConstraints.FreezeRotation;

                    

                    heldRb.collisionDetectionMode = CollisionDetectionMode.Continuous;      // Smooth collision
                    heldRb.interpolation = RigidbodyInterpolation.Interpolate;             // Smooth motion
                    heldRb.linearVelocity = Vector3.zero;

                    isHoldingObject = true;
                    
                }

                else if (hitObject.CompareTag("Pickupable"))
                {
                    //add to imaginary inventory
                }

                else if (hitObject.CompareTag("Door"))
                {
                    //open door ping
                }
                else if (hitObject.CompareTag("Button"))
                {
                    //click button ping
                }
                else if (hitObject.CompareTag("Geocache"))
                {
                    if (Act1)
                    {
                        geoDetector.GeocacheAdditionAct1();
                        Destroy(hitObject);
                    }
                    if (Act2)
                    {
                        geoDetector.GeocacheAdditionAct2();
                        Destroy(hitObject);
                    }
                    if (Act3)
                    {
                        geoDetector.GeocacheAdditionAct3();
                        Destroy(hitObject);
                    }
                }
                
            }
        }
        Ray chray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(chray, out RaycastHit chhit, maxRaycastDist))
        {
            if (isHoldingObject && !chhit.collider.CompareTag("Holdable"))
            {
                isHoldingObject = false;
                heldRb.useGravity = true;
                heldRb.constraints = RigidbodyConstraints.None;

                heldObject = null;
                heldRb = null;
            }
        }
        if (isHoldingObject && Input.GetMouseButtonDown(0))
        {
            isHoldingObject = false;
            heldRb.useGravity = true;
            heldRb.constraints = RigidbodyConstraints.None;
            Vector3 direction = anchor.forward;
            heldRb.AddForce(direction * forceAmount, ForceMode.Impulse);

            heldObject = null;
            heldRb = null;
        }

    }

    private void FixedUpdate()
    {
        if (isHoldingObject && heldRb != null)
        {
            Vector3 direction = anchor.position - heldObject.transform.position;
            heldRb.linearVelocity = direction * 10f; // Follow speed
            Vector3 playerEuler = transform.eulerAngles;
            heldObject.transform.rotation = Quaternion.Euler(playerEuler.x, playerEuler.y, playerEuler.z);
        }

        
    }

}
