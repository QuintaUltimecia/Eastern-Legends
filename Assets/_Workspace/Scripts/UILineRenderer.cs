using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class UILineRenderer : Graphic
{
    [SerializeField]
    private List<Vector2> _points;

    [SerializeField]
    private Vector2Int _gridSize;

    [SerializeField]
    private float _tickness = 10f;

    private float _width;
    private float _height;
    private float _unitWidth;
    private float _unitHeight;

    public void AddPoint(Vector2 pos)
    {
        _points.Add(pos);

        UpdateGeometry();
    }

    public void CleadPoints()
    {
        _points.Clear();

        UpdateGeometry();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        _width = rectTransform.rect.width;
        _height = rectTransform.rect.height;

        _unitWidth = _width / (float)_gridSize.x;
        _unitHeight = _height / (float)_gridSize.y;

        if (_points.Count < 2)
        {
            return;
        }

        float angle = 0;

        for (int i = 0; i < _points.Count; i++)
        {
            Vector2 point = _points[i];

            if (i < _points.Count - 1)
            {
                angle = GetAngle(_points[i], _points[i + 1]) + 45f;
            }

            DrawVerticesForPoint(point, vh, angle);
        }

        for (int i = 0; i < _points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);    
        }
    }

    private float GetAngle(Vector2 me, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - me.y, target.x - me.x) * (180 / Mathf.PI));
    }

    private void DrawVerticesForPoint(Vector2 point, VertexHelper vh, float angle)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-_tickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(_tickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);
    }
}
