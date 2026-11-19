using System;
using System.Collections;
using UnityEngine;
using static TimeUtility;

public class Player : Character ,IDamage,IKnockBack
{
    public Action<float,float> UIEvent;

    Rigidbody _Rb;

    InputControlManager _InputManager;

    Transform _Body;

    [SerializeField]
    float _knockBackSpeed = 5.0f;

    public float CurrentHp
    {
        get => _CurrentHp;

        set
        {
            _CurrentHp = Mathf.Clamp(value,0.0f,100.0f);

            UIEvent?.Invoke(_CurrentHp,MaxHp);
        }
    }
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
