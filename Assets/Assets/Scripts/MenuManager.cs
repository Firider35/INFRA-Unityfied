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

    /*public Animator anim;
    public GameObject mainLaptop;
    public GameObject AnimatedLaptop;
    public Animator projectorAnim;*/

    /*private void Start()
    {
        if (projectorAnim != null)
        {
            projectorAnim.Play("ProjectorRollUp");
            projectorAnim.Play("PullRollUp");
        }
        
    }*/
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
            //mainLaptop.SetActive(false);
            //AnimatedLaptop.SetActive(true);
            //anim.Play("LidClose");
            //anim.Play("Lid1Close");
            /*if (projectorAnim != null)
            {
                projectorAnim.Play("ProjectorRollDown");
                projectorAnim.Play("PullRollDown");
            }*/
            
        }

        if (FrPrTPc)
        {
            menucameramove.PrTPc();
            //mainLaptop.SetActive(true);
            //AnimatedLaptop.SetActive(false);
            /*if (projectorAnim != null)
            {
                projectorAnim.Play("ProjectorRollUp");
                projectorAnim.Play("PullRollUp");
            }*/
            
            
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