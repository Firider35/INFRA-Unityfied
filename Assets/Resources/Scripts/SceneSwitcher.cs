using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string scenename;
    void OnCollisionEnter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scenename);
    }   
}
