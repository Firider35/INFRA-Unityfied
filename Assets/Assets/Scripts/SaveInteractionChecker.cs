using UnityEngine;

public class SaveInteractionChecker : MonoBehaviour
{
    public string uniqueID;
    public bool wasActivated;
    public bool isActive;

    private void Awake()
    {
        isActive = gameObject.activeSelf;
    }
    public void Activation()
    {
        wasActivated = true;
    }
}
