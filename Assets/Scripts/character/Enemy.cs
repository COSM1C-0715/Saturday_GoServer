using UnityEngine;
using System;

public class Enemy : Character
{
    public Action UIEvent;

    Rigidbody _Rb;

    const float SERCH_RANGE = 10;

    Transform _Body;

    protected override void Awake()
    {
        _Rb = GameObject.Find("Enemy").GetComponent<Rigidbody>();

        _CharaStatus = GetComponent<CharaStatus>();

        _Body = transform.GetChild(0);
    }
    void Start()
    {
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

    public void TakeDamage(int amount)
    {
        _CurrentHp -= amount;
    }
}
