using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsScroll : MonoBehaviour
{
    public Transform cameraMove;
    public bool canScroll;
    public GameObject hittableobject;

    public void turnBoolOn()
    {
        canScroll = true;
    }

    public void turnBoolOff()
    {
        canScroll = false;
    }

    public void OnScroll(InputAction.CallbackContext scrollValue)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector2 scrollInput = scrollValue.ReadValue<Vector2>();
            if (scrollInput.y > 0 && canScroll && hit.collider.name == hittableobject.name)
            {
                Debug.Log("Scrolling Up"); //remember to put a math.clamp here
            }

            else if (scrollInput.y < 0 && canScroll && hit.collider.name == hittableobject.name)
            {
                Debug.Log("Scrolling Down");
            }
        }
        
    }
}
