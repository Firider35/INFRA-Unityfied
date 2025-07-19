using UnityEngine;

public class ProxyRaycast : MonoBehaviour
{
    public Camera renderCamera;
    public Renderer screenRenderer;

    public float maxRaycastDist;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, maxRaycastDist))
            {
                if (hit.collider.gameObject == screenRenderer.gameObject)
                {
                    Vector2 pixelUV = hit.textureCoord;
                    Vector2 renderTextureSize = new Vector2(renderCamera.pixelWidth, renderCamera.pixelHeight);

                    Vector3 screenPoint = new Vector3(pixelUV.x * renderTextureSize.x, pixelUV.y * renderTextureSize.y, 0f);
                    Ray uiRay = renderCamera.ScreenPointToRay(screenPoint);
                    if (Physics.Raycast(uiRay, out RaycastHit uiHit, maxRaycastDist))
                    {
                        Debug.Log(uiHit.collider.name);
                    }
                }
            }
        }
    }
}
