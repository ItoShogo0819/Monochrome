using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class SimpleOutline : MonoBehaviour
{
    public Color OutlineColor = Color.black;   // 縁の色
    public float OutlineWidth = 0.05f;         // 縁の太さ（スケール倍率）

    private GameObject outlineObj;

    void Start()
    {
        // 元のMeshとRendererを取得
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // 複製オブジェクトを作成
        outlineObj = new GameObject("Outline");
        outlineObj.transform.SetParent(transform);
        outlineObj.transform.localPosition = Vector3.zero;
        outlineObj.transform.localRotation = Quaternion.identity;
        outlineObj.transform.localScale = Vector3.one * (1f + OutlineWidth);

        // MeshFilter & MeshRenderer追加
        MeshFilter outlineMF = outlineObj.AddComponent<MeshFilter>();
        outlineMF.mesh = meshFilter.mesh;

        MeshRenderer outlineMR = outlineObj.AddComponent<MeshRenderer>();
        outlineMR.material = new Material(Shader.Find("Standard"));
        outlineMR.material.color = OutlineColor;

        // 裏面を描画するように変更（アウトライン用）
        outlineMR.material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Front);
    }
}
