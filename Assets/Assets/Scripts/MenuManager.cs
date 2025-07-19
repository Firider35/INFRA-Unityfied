using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [InspectorName("Turn On")]
    [Tooltip("Group of buttons that will be turned on")]
    public GameObject turnon;
    public AudioSource sourceofaudio;
    public MenuCameraMover menucameramove;
    public SettingsScroll settingsScroll;
    public bool doTurnOnBool = false;


    [Tooltip("Movement from laptop to tablet?")]
    public bool FrPcTTa;
    [Tooltip("Movement from tablet to laptop?")]
    public bool FrTaTPc;
    [Tooltip("Movement from laptop to projector?")]
    public bool FrPcTPr;
    [Tooltip("Movement from projector to laptop?")]
    public bool FrPrTPc;
    private void OnMouseDown()
    {
        gameObject.transform.parent.parent.gameObject.SetActive(false);
        turnon.SetActive(true);
        sourceofaudio.Play();

        if (FrPcTTa)
        {
            menucameramove.PcTTa();
        }

        if (FrTaTPc)
        {
            menucameramove.TaTPc();
        }

        if (FrPcTPr)
        {
            menucameramove.PcTPr();
        }

        if (FrPrTPc)
        {
            menucameramove.PrTPc();
        }

        /*if (doTurnOnBool && FrPcTTa)
        {
            settingsScroll.turnBoolOn();
        }
        else if (!doTurnOnBool && !FrPcTTa)
        {
            settingsScroll.turnBoolOff();
        }*/
    }
}