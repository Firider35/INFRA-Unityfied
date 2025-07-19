using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChapterSelect : MonoBehaviour
{
    public string sceneName;
    private void OnMouseDown()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
