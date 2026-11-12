using UnityEngine;
using static TimeUtility;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody _Rb;

    CharaStatus _Status;

    const int DAMAGE = 1;

    GameObject _Target;

    float _Dis;

    Vector3 _SubDir;

    List<Enemy> _Enemies = new List<Enemy>();

    void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _Status = GetComponent<CharaStatus>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,5.0f);

        for(int i = 0;i < colliders.Length;i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                _Enemies.Add(enemy);
            }
        }

        if(_Enemies.Count > 1)
        {
            for(int i =0;i < _Enemies.Count;i++)
            {
                Vector3 sub = (_Enemies[i].transform.position - transform.position);

                if(_SubDir==Vector3.zero)
                {

                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position,5.0f);
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
