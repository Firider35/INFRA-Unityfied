using TMPro;
using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    public GameObject button;
    public TextMeshPro textText;
    public TextMeshPro textButton;

    public Color textColor = Color.white;
    public Color textHoverColor = Color.black;

    public void OnMouseEnter()
    {
        button.GetComponent<Renderer>().enabled = true;
        textText.color = textHoverColor;
        textButton.color = textHoverColor;
    }

    public void OnMouseExit()
    {
        button.GetComponent<Renderer>().enabled = false;
        textText.color = textColor;
        textButton.color = textColor;
    }






}
