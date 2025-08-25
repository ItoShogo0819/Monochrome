using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("�ǐՑΏ�")]
    public Transform Target;

    [Header("�J�����ʒu�I�t�Z�b�g")]
    public Vector3 Offset = new Vector3(0, 5, -8);

    [Header("�Ǐ]���x")]
    public float FollowSpeed = 30f;

    [Header("��]�X���[�Y���x")]
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
