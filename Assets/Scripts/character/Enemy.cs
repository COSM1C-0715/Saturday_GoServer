using UnityEngine;
using System;

public class Enemy : Character,IDamage
{
    public Action<float,float> UIEvent;

    Rigidbody _Rb;

    const float SERCH_RANGE = 10;

    Transform _Body;

    public float CurrentHp
    {
        get => _CurrentHp;

        set
        {
            _CurrentHp = Mathf.Clamp(value, 0.0f, 100.0f);

            UIEvent?.Invoke(_CurrentHp, MaxHp);
        }
    }

    protected override void Awake()
    {
        _Rb = GameObject.Find("Enemy").GetComponent<Rigidbody>();

        _CharaStatus = GetComponent<CharaStatus>();

        _Body = transform.GetChild(0);
    }
    void Start()
    {
        _CurrentHp = _CharaStatus._MaxHp;

        Move();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Character chara = StaticCharacterMove.SerchTarget<Player>(transform.position,SERCH_RANGE);

        if (chara != null)
        {
            _Rb.linearVelocity = StaticCharacterMove.AttackDir(chara.transform.position, _Body, _CharaStatus._Speed);
        }
    }
}
