using System.Collections.Generic;
using UnityEngine;
using static TimeUtility;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody _Rb;

    CharaStatus _Status;
    
    const int DAMAGE = 1;//ãÖÇ™ìñÇΩÇ¡ÇΩëŒè€Ç…â¡Ç¶ÇÈÉ_ÉÅÅ[ÉW

    const float SERCH_RANGE = 10;
    void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _Status = GetComponent<CharaStatus>();
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

    public void Attack(Vector3 direction)
    {
        transform.forward = direction.normalized;

         var move = direction.normalized * _Status._Speed * GameTime.FixedDeltaTime;

         _Rb.linearVelocity = move;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamage>(out IDamage damage))
        {
            damage.TakeDamage(DAMAGE);
        }
    }
}
