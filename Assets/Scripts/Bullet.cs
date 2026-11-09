using UnityEngine;
using static TimeUtility;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody _Rb;

    CharaStatus _Status;

    const int DAMAGE = 1;

    void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _Status = GetComponent<CharaStatus>();
    }

    public void Attack(Vector3 direction)
    {
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
