using UnityEngine;

public class CorruptionDetector : MonoBehaviour
{

    public ProgressManager photoManager;

    public void CorruptionAdditionAct1()
    {
        photoManager.Act1Corruption++;
    }
    public void CorruptionAdditionAct2()
    {
        photoManager.Act2Corruption++;
    }
    public void CorruptionAdditionAct3()
    {
        photoManager.Act3Corruption++;
    }
}
