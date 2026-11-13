using UnityEngine;
using static TimeUtility;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody _Rb;

    CharaStatus _Status;
    
    const int DAMAGE = 1;//ãÖÇ™ìñÇΩÇ¡ÇΩëŒè€Ç…â¡Ç¶ÇÈÉ_ÉÅÅ[ÉW

    int _Duration = 3;

    Vector3 _CurrentDir;

    List<Enemy> _Enemies = new List<Enemy>();

    void Awake()
    {
        _Rb = GetComponent<Rigidbody>();

        _Status = GetComponent<CharaStatus>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,5.0f);

        Enemy closestEnemy = null;

        float minDistance = 100;

        for(int i = 0;i < colliders.Length;i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                float sqrDis = (enemy.transform.position - transform.position).sqrMagnitude;

                if(sqrDis < minDistance)
                {
                    minDistance = sqrDis;

                    closestEnemy = enemy;
                }
            }
        }

        if(closestEnemy != null)
        {
            Vector3 targetDir = (closestEnemy.transform.position - transform.position).normalized;

            float dot = Vector3.Dot(targetDir,transform.forward);

            if (dot > 1.0f) return;

            Vector3 cross = Vector3.Cross(transform.forward,targetDir);

            float aCos = Mathf.Min(Mathf.Acos(dot),50.0f * Mathf.Deg2Rad);

            aCos *= (cross.y / Mathf.Abs(cross.y));

            Vector3 angle = transform.eulerAngles;

            angle.y += aCos * Mathf.Rad2Deg;

            transform.eulerAngles = angle;

            var move = transform.forward * _Status._Speed * GameTime.FixedDeltaTime;

            _Rb.linearVelocity = move;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position,5.0f);
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
