using System.Collections;
using UnityEngine;
using static TimeUtility;

public class Player : Character ,IKnockBack
{
    Rigidbody _Rb;

    InputControlManager _InputManager;

    Transform _Body;

    Character _Chara;

    [SerializeField]
    float _SearchRange = 5.0f;

    [SerializeField]
    float _knockBackSpeed = 5.0f;

    public Character Chara => _Chara;
    bool _IsBack = false;

    protected override void Awake()
    {
        _InputManager = GetComponent<InputControlManager>();
        _CharaStatus = GetComponent<CharaStatus>();
        _Body = GameObject.Find("Player").transform.GetChild(0);
        _Rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void Start()
    {
        _CurrentHp = _CharaStatus._MaxHp;
    }
    void FixedUpdate()
    {
        _Chara = StaticCharacterMove.SerchTarget<Enemy>(transform.position, _SearchRange);

        if (_IsBack) return;
        Move(_InputManager.GetInputVer);
    }

    void Move(Vector2 input)
    {
        //à⁄ìÆ
        var move = CalculateMove(input);

        if(_Rb != null)
        {
            _Rb.linearVelocity = move;
        }

        if(move != Vector3.zero&& _Body != null)
        {
            _Body.rotation = CalculateRotation(input);
        }
    }
    Vector3 CalculateMove(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y) * _CharaStatus._Speed * GameTime.FixedDeltaTime;
    }

    Quaternion CalculateRotation(Vector2 input)
    {
        //Vector3Ç…ïœä∑
        var dir = new Vector3(input.x, 0, input.y);

        //åàÇﬂÇΩâÒì]ï˚å¸ÇtargetRotationÇ…ë„ì¸ÇµÇƒÇ¢ÇÈ
        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        //âÒì]
        return Quaternion.Slerp(_Body.rotation, targetRotation, _CharaStatus._RotSpeed * GameTime.FixedDeltaTime);
    }

    public void KnockBack(Vector3 pos)
    {
        StartCoroutine(BackCoroutine(pos));
    }

    IEnumerator BackCoroutine(Vector3 fromPos)
    {
        _IsBack = true;

        Debug.Log("É_ÉÅÅ[ÉWÇéÛÇØÇΩ");

        Vector3 dir = transform.position - fromPos;

        dir = dir.normalized;

        dir.y = 1.0f;

        Vector3 force = dir * _knockBackSpeed;

        if(_Rb != null)
        {
            _Rb.linearVelocity = Vector3.zero;

            _Rb.AddForce(force, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(2f);

        _IsBack = false;
    }
}
