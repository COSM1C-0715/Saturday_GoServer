using System;
using System.Collections;
using UnityEngine;
using static TimeUtility;

public class Player : Character , IDamage
{
    public Action UIEvent;

    Rigidbody _Rb;

    InputControlManager _InputManager;

    Vector3 _BackDir = new Vector3(0.0f,5.0f,-5.0f);

    bool _IsBack = false;

    Transform _Body;

    protected override void Awake()
    {
        _InputManager = GetComponent<InputControlManager>();
        _CharaStatus = GetComponent<CharaStatus>();
        _Body = GameObject.Find("Player").transform.GetChild(0);
        _Rb = _Body.GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        _CurrentHp = _CharaStatus._MaxHp;
    }
    protected override void FixedUpdate()
    {
        if (_IsBack) return;
        Move(_InputManager.GetInputVer);
    }

    void Move(Vector2 input)
    {
        //ˆÚ“®
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
        //Vector3‚É•ÏŠ·
        var dir = new Vector3(input.x, 0, input.y);

        //Œˆ‚ß‚½‰ñ“]•ûŒü‚ðtargetRotation‚É‘ã“ü‚µ‚Ä‚¢‚é
        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        //‰ñ“]
        return Quaternion.Slerp(_Body.rotation, targetRotation, _CharaStatus._RotSpeed * GameTime.FixedDeltaTime);
    }

    public void KnockBack()
    {
        StartCoroutine(BackCoroutine());
    }

    public void TakeDamage(int amount)
    {
        _CurrentHp -= amount;
        UIEvent?.Invoke();
    }

    IEnumerator BackCoroutine()
    {
        _IsBack = true;

        _Rb.AddForce(_BackDir,ForceMode.Impulse);

        yield return new WaitForSeconds(2f);

        _IsBack = false;
    }
}
