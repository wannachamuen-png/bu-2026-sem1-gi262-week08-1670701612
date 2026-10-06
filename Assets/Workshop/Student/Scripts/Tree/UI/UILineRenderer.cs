using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasRenderer))]
public class UILineRenderer : MaskableGraphic
{
    public Transform[] points;

    public float thickness = 10f;
    public bool center = true;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        if (points == null || points.Length < 1)
            return;

        // **�ش�����������:** ����˹觢ͧ GameObject ���ʤ�Ի����Ṻ����
        Vector3 startPoint = transform.position;

        // **���ҧ Vertex Template ����Ѻ Beveled Edges (�����)**
        // ���ͧ�ҡ�ç���ҧ����Ҵ����¹� (�ҡ�ش������ѧ���¨ش)
        // Logic ������ҧ Beveled Edges Ẻ����Ҩ��ͧ��Ѻ��ا
        // ��������� ���Ҵ��鹨ҡ startPoint ��ѧ�ش�á� points[0]
        // �ҡ����Ҵ��������ҧ points[i] �Ѻ points[i+1] (�����) 

        // *******************************************************************
        // ********* 1. ���ҧ Segment �á: �ҡ transform.position ��ѧ points[0] *********
        // *******************************************************************
        CreateLineSegment(startPoint, points[0].position, vh);

        int index = 0;

        // Add the line segment to the triangles array (Segment 0)
        vh.AddTriangle(index, index + 1, index + 3);
        vh.AddTriangle(index + 3, index + 2, index);


        // *******************************************************************
        // ********* 2. ���ҧ Segment �Ѵ�: �ҡ points[i] ��ѧ points[i+1] *********
        // *******************************************************************
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector3 p1 = points[i].position;
            Vector3 p2 = points[i + 1].position;

            // ���ҧ segment �����ҧ points[i] ��� points[i+1]
            CreateLineSegment(p1, p2, vh);

            // �ӹǳ Index ����Ѻ Segment ���� (������鹷�� Segment 1)
            // Index ����Ѻ Segment 1 ��������鹷�� vh.currentVertCount ��͹���¡ CreateLineSegment
            // ���ͧ�ҡ vh.currentVertCount ����ҡѺ 5 ��ѧ Segment �á�١���ҧ

            index = (i + 1) * 5; // Index ����Ѻ Segment ��� i+1 (������鹷�� 5, 10, 15, ...)

            // Add the line segment to the triangles array
            vh.AddTriangle(index, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index);

            // These two triangles create the beveled edges
            // ���������Ѻ Beveled Edges �ѧ�����������ѹ�� index �ͧ Segment ������� (index - 5)
            // ����Ѻ Segment �á (i=0) ���������� Segment 0 �Ѻ Segment 1
            if (i >= 0) // i = 0 ��� Segment ��� 1 (����� Segment 0)
            {
                vh.AddTriangle(index, index - 1, index - 3);
                vh.AddTriangle(index + 1, index - 1, index - 2);
            }
        }
    }

    /// <summary>
    /// Creates a rect from two points that acts as a line segment
    /// </summary>
    /// <param name="point1">The starting point of the segment</param>
    /// <param name="point2">The endint point of the segment</param>
    /// <param name="vh">The vertex helper that the segment is added to</param>
    private void CreateLineSegment(Vector3 point1, Vector3 point2, VertexHelper vh)
    {
        // ��÷ӧҹ�����ѧ������͹��� ���Шش���ʧ���͡�����ҧ segment �ҡ 2 �ش��������
        Vector3 offset = center ? (rectTransform.sizeDelta / 2) : Vector2.zero;

        // Create vertex template
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        // Create the start of the segment
        Quaternion point1Rotation = Quaternion.Euler(0, 0, RotatePointTowards(point1, point2) + 90);
        vertex.position = point1Rotation * new Vector3(-thickness / 2, 0);
        vertex.position += point1 - offset;
        vh.AddVert(vertex);
        vertex.position = point1Rotation * new Vector3(thickness / 2, 0);
        vertex.position += point1 - offset;
        vh.AddVert(vertex);

        // Create the end of the segment
        Quaternion point2Rotation = Quaternion.Euler(0, 0, RotatePointTowards(point2, point1) - 90);
        vertex.position = point2Rotation * new Vector3(-thickness / 2, 0);
        vertex.position += point2 - offset;
        vh.AddVert(vertex);
        vertex.position = point2Rotation * new Vector3(thickness / 2, 0);
        vertex.position += point2 - offset;
        vh.AddVert(vertex);

        // Also add the end point
        vertex.position = point2 - offset;
        vh.AddVert(vertex);
    }

    /// <summary>
    /// Gets the angle that a vertex needs to rotate to face target vertex
    /// </summary>
    /// <param name="vertex">The vertex being rotated</param>
    /// <param name="target">The vertex to rotate towards</param>
    /// <returns>The angle required to rotate vertex towards target</returns>
    private float RotatePointTowards(Vector2 vertex, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - vertex.y, target.x - vertex.x) * (180 / Mathf.PI));
    }
}