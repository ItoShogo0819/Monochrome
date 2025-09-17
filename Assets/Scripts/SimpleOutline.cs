using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class SimpleOutline : MonoBehaviour
{
    public Color OutlineColor = Color.black;   // ���̐F
    public float OutlineWidth = 0.05f;         // ���̑����i�X�P�[���{���j

    private GameObject outlineObj;

    void Start()
    {
        // ����Mesh��Renderer���擾
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // �����I�u�W�F�N�g���쐬
        outlineObj = new GameObject("Outline");
        outlineObj.transform.SetParent(transform);
        outlineObj.transform.localPosition = Vector3.zero;
        outlineObj.transform.localRotation = Quaternion.identity;
        outlineObj.transform.localScale = Vector3.one * (1f + OutlineWidth);

        // MeshFilter & MeshRenderer�ǉ�
        MeshFilter outlineMF = outlineObj.AddComponent<MeshFilter>();
        outlineMF.mesh = meshFilter.mesh;

        MeshRenderer outlineMR = outlineObj.AddComponent<MeshRenderer>();
        outlineMR.material = new Material(Shader.Find("Standard"));
        outlineMR.material.color = OutlineColor;

        // ���ʂ�`�悷��悤�ɕύX�i�A�E�g���C���p�j
        outlineMR.material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Front);
    }
}
