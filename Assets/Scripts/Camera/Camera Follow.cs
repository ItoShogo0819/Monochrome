using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追跡対象")]
    public Transform Target;

    [Header("カメラ位置オフセット")]
    public Vector3 Offset = new Vector3(0, 5, -8);

    [Header("追従速度")]
    public float FollowSpeed = 30f;

    [Header("回転スムーズ速度")]
    public float RotationSpeed = 12f;

    void LateUpdate()
    {
        if (Target == null) return;

        Vector3 desiredPos = Target.position + Offset;

        transform.position = Vector3.Lerp(transform.position, desiredPos, FollowSpeed * Time.deltaTime);

        Vector3 lookPoint = Target.position + Target.forward * 2f + Vector3.up * 1.5f;
        Quaternion targetRot = Quaternion.LookRotation(lookPoint - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation,targetRot,RotationSpeed * Time.deltaTime);
    }
}
