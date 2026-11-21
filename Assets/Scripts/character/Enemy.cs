using UnityEngine;

public class Enemy : Character
{
    Rigidbody _Rb;

    Transform _Body;

    const float SERCH_RANGE = 10;

    protected override void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

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

    protected override void OnTriggerEnter(Collider other)
    {
        IDamage damage = other.GetComponent<IDamage>();

        IKnockBack knockBack = other.GetComponent<IKnockBack>();

        if (damage != null)
        {
            damage.CurrentHp -= DAMAGE;
        }

        if (knockBack != null)
        {
            knockBack.KnockBack(transform.position);
        }

        if(_CurrentHp <=0)
        {
            _Return?.Invoke(this);
        }
    }
}
