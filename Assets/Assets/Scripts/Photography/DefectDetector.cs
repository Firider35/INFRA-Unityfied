using UnityEngine;

public class DefectDetector : MonoBehaviour
{
    public ProgressManager photoManager;

    public void DefectAdditionAct1()
    {
        photoManager.Act1Defects++;
    }
    public void DefectAdditionAct2()
    {
        photoManager.Act2Defects++;
    }
    public void DefectAdditionAct3()
    {
        photoManager.Act3Defects++;
    }
}
