using UnityEngine;

public class ColorChangeDead : MonoBehaviour
{
    [Header("�F�ݒ�")]
    public Color colorA = Color.white;
    public Color colorB = Color.black;
    public PlayerColorType TypeA = PlayerColorType.White;
    public PlayerColorType TypeB = PlayerColorType.Black;

    [Header("�ؑ֐ݒ�")]
    public float Interval = 1f;
    private float _timer;
    private bool _isColorA = true;

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();  // �����_���[�擾
        _rend.material.color = colorA;     // �����F�ݒ�
        _timer = Interval;                 // �^�C�}�[������
    }

    void Update()
    {
        _timer -= Time.deltaTime;          // �^�C�}�[���Z
        if (_timer <= 0f)
        {
            _isColorA = !_isColorA;        // �F�ؑ�

            if (_isColorA)
            {
                _rend.material.color = colorA; // �FA�ɕύX
            }
            else
            {
                _rend.material.color = colorB; // �FB�ɕύX
            }

            _timer = Interval;             // �^�C�}�[���Z�b�g
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return; // �v���C���[�ȊO�͖���

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return; // PlayerColor�R���|�[�l���g���Ȃ���Ζ���

        // ���݂̐F�ƃv���C���[�F����v�����玀�S����
        if ((_isColorA && pc.playerColor == TypeA) || (!_isColorA && pc.playerColor == TypeB))
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject); // ���S�����Ăяo��
            }
        }
    }
}
