using UnityEngine;
using System;

public class Enemy : Character,IDamage
{
    public Action UIEvent;

    Rigidbody _Rb;

    Vector3 _MoveDir;

    protected override void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _CharaStatus = GetComponent<CharaStatus>();
    }
    protected override void Start()
    {
        _MoveDir = new Vector3(0, 0, 1);
    }

    protected override void FixedUpdate()
    {
        var move = _MoveDir * _CharaStatus._Speed * Time.fixedDeltaTime;

        _Rb.linearVelocity = move;
    }

    public void TakeDamage(int amount)
    {
        _CurrentHp -= amount;
    }
}
