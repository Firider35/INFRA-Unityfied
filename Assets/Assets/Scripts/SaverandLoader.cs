using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class SaverandLoader : MonoBehaviour
{
    public bool Save;
    public string SaveName;
    public TextMeshPro nameOfSave;

    private void Start()
    {
        if (!Save && nameOfSave)
        {
            SaveData data = SaveManager.instance.ReadSaveData(SaveName);
            if (data != null)
            {
                if (SaveName == "LatestAutosave")
                {
                    int chapter = SaveManager.instance.currentChapter;
                    nameOfSave.text = $"{SaveName} - CHAPTER {chapter}";
                    //Display "LATEST AUTOSAVE - CHAPTER #"
                }
                else if (SaveName == "OlderAutosave")
                {
                    int chapter = SaveManager.instance.currentChapter;
                    nameOfSave.text = $"{SaveName} - CHAPTER {chapter}";
                    //Display "OLDER AUTOSAVE - CHAPTER #"
                }
                else if (SaveName == "QuickSave")
                {
                    //Display "QUICKSAVE"
                    nameOfSave.text = "QUICKSAVE";
                }
                else if (SaveName == null)
                {
                    return;
                }
                else
                {
                    float time = data.playTime;
                    int hours = Mathf.FloorToInt(time / 3600);
                    int minutes = Mathf.FloorToInt((time % 3600) / 60);
                    int chapter = data.currentChapter;
                    //Display "SAVE SLOT # - CH. # TIME"
                    nameOfSave.text = $"{SaveName} - CH {chapter}, {hours} H {minutes} MIN";
                    Debug.Log("The text changed");
                    Debug.Log("The time is: " + hours + "H " + minutes + "MIN");


                }
            }
        }
        
    }
    private void OnMouseDown()
    {
        if (Save)
        {
           SaveManager.instance.SaveToFile(SaveName);
            Debug.Log("Game saved to: " +  SaveName);
        }
        else
        {
            SaveManager.instance.LoadFromFile(SaveName);
            Debug.Log("Attempting to load " + SaveName);
        }
    }
}
