using UnityEngine;
using System;

public class Enemy : Character,IDamage
{
    public Action UIEvent;

    Rigidbody _Rb;

    const float SERCH_RANGE = 10;

    const int DAMAGE = 10;

    Transform _Body;

    protected override void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _CharaStatus = GetComponent<CharaStatus>();

        _Body = GameObject.Find("Enemy").transform.GetChild(0);
    }
    protected override void Start()
    {
        Move();
    }

    protected override void FixedUpdate()
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out var chara))
        {
            chara.KnockBack();
            chara.TakeDamage(DAMAGE);
        }
    }
}
