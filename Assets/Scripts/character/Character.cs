using UnityEngine;
public class Character : MonoBehaviour
{
    protected CharaStatus _CharaStatus;

    protected float _CurrentHp;

    protected const int DAMAGE = 10;

    public float MaxHp => _CharaStatus._MaxHp;

    protected virtual void Awake()
    {
        _CharaStatus = GetComponent<CharaStatus>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        IKnockBack knockBack = other.GetComponentInParent<IKnockBack>();

        if(other.TryGetComponent<Player>(out var chara))
        {
            chara.CurrentHp -= DAMAGE;
        }

        if(knockBack != null)
        {
            knockBack.KnockBack(transform.position);
        }
    }
}
