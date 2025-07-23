using UnityEngine;
[CreateAssetMenu(
    fileName = "ProgressManager",
    menuName = "Scripts/ProgressManager")]
public class ProgressManager : ScriptableObject
{
    [Header("Defects")]
    public int Act1Defects;
    public int Act2Defects;
    public int Act3Defects;

    [Header("Corruption")]
    public int Act1Corruption;
    public int Act2Corruption;
    public int Act3Corruption;

    [Header("Repairs")]
    public int Act1Repairs;
    public int Act2Repairs;
    public int Act3Repairs;

    [Header("Geocaches")]
    public int Act1Geocaches;
    public int Act2Geocaches;
    public int Act3Geocaches;

    [Header("Water Flow Meters")]
    public int Act1WaterFlow;
    public int Act2WaterFlow;
    public int Act3WaterFlow;

    [Header("Mistake Targets")]
    public int Act1Mistakes;
    public int Act2Mistakes;
    public int Act3Mistakes;
}
