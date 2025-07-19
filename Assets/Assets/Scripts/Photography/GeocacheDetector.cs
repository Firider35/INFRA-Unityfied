using UnityEngine;

public class GeocacheDetector : MonoBehaviour
{
    public ProgressManager photoManager;

    public void GeocacheAdditionAct1()
    {
        photoManager.Act1Geocaches++;
    }
    public void GeocacheAdditionAct2()
    {
        photoManager.Act2Geocaches++;
    }
    public void GeocacheAdditionAct3()
    {
        photoManager.Act3Geocaches++;
    }
}
