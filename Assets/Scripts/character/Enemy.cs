using UnityEngine;

public class Enemy : Character,IDamage
{
    Rigidbody Rb;

    Vector3 MoveDir;

    CharaStatus Status;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();

        Status = GetComponent<CharaStatus>();
    }
    protected override void Start()
    {
        MoveDir = new Vector3(0, 0, 1);
    }

    protected override void FixedUpdate()
    {
        var move = MoveDir * Status.Speed * Time.fixedDeltaTime;

        Rb.linearVelocity = move;
    }

    public void TakeDamage(int amount)
    {
        Status.MaxHp -= amount;
    }
}
