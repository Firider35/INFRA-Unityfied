using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneProgressManager : MonoBehaviour
{
    public int AvailableDefects;
    public int AvailableCorruption;
    public int AvailableRepairs;
    public int AvailableGeocaches;
    public int AvailableWaterFlowMeters;
    public int AvailableMistakeTargets;

    public TextMeshProUGUI defectCounter;
    public TextMeshProUGUI corruptionCounter;
    public TextMeshProUGUI repairCounter;
    public TextMeshProUGUI geocacheCounter;
    public TextMeshProUGUI waterFlowCounter;
    public TextMeshProUGUI mistakeTargetCounter;
    public TextMeshProUGUI sceneName;

    
    void Start()
    {
        string sceneNameDetect = SceneManager.GetActiveScene().name;
        sceneName.text = sceneNameDetect;
        AvailableDefects = FindObjectsByType<DefectDetector>(FindObjectsSortMode.None).Length;
        AvailableCorruption = FindObjectsByType<CorruptionDetector>(FindObjectsSortMode.None).Length;
        AvailableRepairs = FindObjectsByType<CorruptionDetector>(FindObjectsSortMode.None).Length;//nonexistent
        AvailableGeocaches = FindObjectsByType<GeocacheDetector>(FindObjectsSortMode.None).Length;
    }

    void Update()
    {
        int DefectCheck = FindObjectsByType<DefectDetector>(FindObjectsSortMode.None).Length;
        int PicturedDefects = AvailableDefects - DefectCheck;

        int CorruptionCheck = FindObjectsByType<CorruptionDetector>(FindObjectsSortMode.None).Length;
        int PicturedCorruption = AvailableCorruption - CorruptionCheck;

        //insert Repairs here

        int GeocacheCheck = FindObjectsByType<GeocacheDetector>(FindObjectsSortMode.None).Length;
        int TakenCaches = AvailableGeocaches - GeocacheCheck;
        defectCounter.text = PicturedDefects + "/" + AvailableDefects;
        if (PicturedDefects == AvailableDefects)
        {
            defectCounter.color = Color.green;
            TextMeshProUGUI defect = defectCounter.transform.parent.GetComponent<TextMeshProUGUI>();
            defect.color = Color.green;
        }
        corruptionCounter.text = PicturedCorruption + "/" + AvailableCorruption;
        if (PicturedCorruption == AvailableCorruption)
        {
            corruptionCounter.color = Color.green;
            TextMeshProUGUI corruption = corruptionCounter.transform.parent.GetComponent<TextMeshProUGUI>();
            corruption.color = Color.green;
        }

        //insert repair counter

        geocacheCounter.text = TakenCaches + "/" + AvailableGeocaches;
        if (TakenCaches == AvailableGeocaches)
        {
            geocacheCounter.color = Color.green;
            TextMeshProUGUI cache = geocacheCounter.transform.parent.GetComponent<TextMeshProUGUI>();
            cache.color = Color.green;
        }
    }
}
