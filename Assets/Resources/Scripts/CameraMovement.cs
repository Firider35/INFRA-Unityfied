using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2f;
    public Transform playerBody;
    float xRotation = 0f;
    public float debounce = 0.1f;
    public float timeSinceActivation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceActivation += Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);


        if (timeSinceActivation >= debounce)
        {
            if (Input.GetKeyDown(KeyCode.C) && sensitivity == 2f) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                sensitivity = 0f;
                timeSinceActivation = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.C) && sensitivity == 0f)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                sensitivity = 2f;
                timeSinceActivation = 0f;
            }
        }
    }
}