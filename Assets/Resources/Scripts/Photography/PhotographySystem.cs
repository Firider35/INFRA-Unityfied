using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PhotographySystem : MonoBehaviour
{
    public bool debounce;
    public Camera secondaryCamera;
    //insert measuring script here
    public int raycastMaxDist;
    public bool Act1;
    public bool Act2;
    public bool Act3;

    public AudioSource successfulPhoto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Button has been clicked");
            if (secondaryCamera.enabled)
            {
                Debug.Log("Secondary Camera Active");
                if (!debounce)
                {
                    Ray ray = secondaryCamera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit, raycastMaxDist))
                    {
                        Debug.Log("Ray Successful");
                        if (Act1)
                        {
                            Debug.Log("Act 1 Chosen");
                            if (hit.collider.GetComponent<DefectDetector>() != null)
                            {
                                Debug.Log("Defect Detector Found");
                                GameObject hitObject = hit.collider.gameObject;
                                DefectDetector defects = hitObject.GetComponent<DefectDetector>();
                                defects.DefectAdditionAct1();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }

                            else if (hit.collider.GetComponent<CorruptionDetector>() != null)
                            {
                                GameObject hitObject = hit.collider.gameObject;
                                CorruptionDetector corruption = hitObject.GetComponent<CorruptionDetector>();
                                corruption.CorruptionAdditionAct1();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }
                        }
                        else if (Act2)
                        {
                            if (hit.collider.GetComponent<DefectDetector>() != null)
                            {
                                GameObject hitObject = hit.collider.gameObject;
                                DefectDetector defects = hitObject.GetComponent<DefectDetector>();
                                defects.DefectAdditionAct2();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }

                            else if (hit.collider.GetComponent<CorruptionDetector>() != null)
                            {
                                GameObject hitObject = hit.collider.gameObject;
                                CorruptionDetector corruption = hitObject.GetComponent<CorruptionDetector>();
                                corruption.CorruptionAdditionAct2();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }
                        }
                        else if (Act3)
                        {
                            if (hit.collider.GetComponent<DefectDetector>() != null)
                            {
                                GameObject hitObject = hit.collider.gameObject;
                                DefectDetector defects = hitObject.GetComponent<DefectDetector>();
                                defects.DefectAdditionAct3();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }

                            else if (hit.collider.GetComponent<CorruptionDetector>() != null)
                            {
                                GameObject hitObject = hit.collider.gameObject;
                                CorruptionDetector corruption = hitObject.GetComponent<CorruptionDetector>();
                                corruption.CorruptionAdditionAct3();
                                successfulPhoto.Play();
                                hitObject.SetActive(false);
                            }
                        }
                        //Check for hit
                        
                    }
                }
            }
        }
        
        if (debounce)
        {
            //wait 0,1 sec
            debounce = false;

        }
    }
}
