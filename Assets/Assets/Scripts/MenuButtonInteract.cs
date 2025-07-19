using UnityEngine;
using TMPro;

public class MenuButtonInteract : MonoBehaviour
{
    public Renderer buttonRenderer;
    public TextMeshPro text;

    public Color normalTextColor = Color.white;
    public Color hoverTextColor = Color.black;

    private void Start()
    {
        // Ensure emission is enabled on start
        if (buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            buttonRenderer.material.EnableKeyword("_EMISSION");
            buttonRenderer.material.SetColor("_EmissionColor", Color.white);
            DynamicGI.SetEmissive(buttonRenderer, Color.black);
        }

        // Set initial colors
        buttonRenderer.enabled = false;
        text.color = normalTextColor;
    }
    private void OnMouseEnter()
    {
        buttonRenderer.enabled = true;

        // Change text color
        text.color = hoverTextColor;
    }

    private void OnMouseExit()
    {
        // Revert button base color
        buttonRenderer.enabled = false;

        // Revert text color
        text.color = normalTextColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("Button clicked!");
        // Add your button click logic here
    }
}
