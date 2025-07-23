using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public AudioSource menuclick;
    private void OnMouseDown()
    {
        Application.Quit();
        menuclick.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
