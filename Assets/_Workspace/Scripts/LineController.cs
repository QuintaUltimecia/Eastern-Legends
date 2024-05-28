using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private UILineRenderer[] _lineRenderers;

    public UILineRenderer GetRendererAt(int index) =>
        _lineRenderers[index];
}