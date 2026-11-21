using UnityEngine;
using System;
using System.Collections;
using static TimeUtility;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Coroutine _HideCoroutine = null;

    Action<Bullet> _Return;

    Rigidbody _Rb;

    CharaStatus _Status;

    const int DAMAGE = 1;//ãÖÇ™ìñÇΩÇ¡ÇΩëŒè€Ç…â¡Ç¶ÇÈÉ_ÉÅÅ[ÉW

    [SerializeField]
    float _ActiveTime = 5f;

    const float SERCH_RANGE = 10;
    void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _Status = GetComponent<CharaStatus>();
    }

    void Start()
    {
        _HideCoroutine = StartCoroutine(DerayHide());
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Character chara = StaticCharacterMove.SerchTarget<Enemy>(transform.position,SERCH_RANGE);

        if (chara != null)
        {
            _Rb.linearVelocity = StaticCharacterMove.AttackDir(chara.transform.position, this.transform, _Status._Speed);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position,SERCH_RANGE);
    }

    public void Attack(Vector3 direction,Action<Bullet> poolReturn)
    {
        _Return = poolReturn;

        transform.forward = direction.normalized;

        var move = direction.normalized * _Status._Speed * GameTime.FixedDeltaTime;

        _Rb.linearVelocity = move;
    }

    IEnumerator DerayHide()
    {
        yield return new WaitForSeconds(_ActiveTime);

        _Return?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damage = other.GetComponent<IDamage>();

        if (damage != null)
        {
            damage.CurrentHp -= DAMAGE;
        }

        if(_HideCoroutine != null)
        {
            StopCoroutine(_HideCoroutine);
            _HideCoroutine = null;
        }

        _Return?.Invoke(this);
    }
}
