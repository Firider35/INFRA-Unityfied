using JetBrains.Annotations;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public ProgressManager progress;
    private float playTime = 0f;
    public int currentChapter = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        currentChapter = GetCurrentChapter();


    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }

    public void SaveToFile(string saveSlot)
    {
        SaveData data = new SaveData()
        {
            playTime = playTime,
            Act1Defects = progress.Act1Defects,
            Act2Defects = progress.Act2Defects,
            Act3Defects = progress.Act3Defects,

            Act1Corruption = progress.Act1Corruption,
            Act2Corruption = progress.Act2Corruption,
            Act3Corruption = progress.Act3Corruption,

            Act1Repairs = progress.Act1Repairs,
            Act2Repairs = progress.Act2Repairs,
            Act3Repairs = progress.Act3Repairs,

            Act1Geocaches = progress.Act1Geocaches,
            Act2Geocaches = progress.Act2Geocaches,
            Act3Geocaches = progress.Act3Geocaches,

            Act1WaterFlow = progress.Act1WaterFlow,
            Act2WaterFlow = progress.Act2WaterFlow,
            Act3WaterFlow = progress.Act3WaterFlow,

            Act1Mistakes = progress.Act1Mistakes,
            Act2Mistakes = progress.Act2Mistakes,
            Act3Mistakes = progress.Act3Mistakes,

            currentChapter = currentChapter,
            currentSceneName = SceneManager.GetActiveScene().name

        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/" + saveSlot + ".json", json);
    }

    public SaveData ReadSaveData(string saveSlot)
    {
        string path = Application.persistentDataPath + "/" + saveSlot + ".json";
        if (!File.Exists(path)) return null;
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }
    public SaveData LoadFromFile(string saveSlot)
    {
        SaveData data = ReadSaveData(saveSlot);

            playTime = data.playTime;
            
            progress.Act1Defects = data.Act1Defects;
            progress.Act2Defects = data.Act2Defects;
            progress.Act3Defects = data.Act3Defects;

            progress.Act1Corruption = data.Act1Corruption;
            progress.Act2Corruption = data.Act2Corruption;
            progress.Act3Corruption = data.Act3Corruption;

            progress.Act1Repairs = data.Act1Repairs;
            progress.Act2Repairs = data.Act2Repairs;
            progress.Act3Repairs = data.Act3Repairs;

            progress.Act1Geocaches = data.Act1Geocaches;
            progress.Act2Geocaches = data.Act2Geocaches;
            progress.Act3Geocaches = data.Act3Geocaches;

            progress.Act1WaterFlow = data.Act1WaterFlow;
            progress.Act2WaterFlow = data.Act2WaterFlow;
            progress.Act3WaterFlow = data.Act3WaterFlow;

            progress.Act1Mistakes = data.Act1Mistakes;
            progress.Act2Mistakes = data.Act2Mistakes;
            progress.Act3Mistakes = data.Act3Mistakes;
            
            currentChapter = data.currentChapter;
            SceneManager.LoadScene(data.currentSceneName);
        return data;
    }
    public float GetPlayTime()
    {
        return playTime;
    }

    private int GetCurrentChapter()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (sceneName.Contains("Ch"))
        {
            int chIndex = sceneName.IndexOf("Ch") + 2;

            string numberPart = new string(sceneName
                .Skip(chIndex)
                .TakeWhile(char.IsDigit)
                .ToArray());

            if (int.TryParse(numberPart, out int chapter))
            {
                return chapter;
            }
        }

        return -1;
    }
}