using UnityEngine;
using static TimeUtility;

public class Player : Character , IDamage
{
    Rigidbody _Rb;

    InputControlManager _InputManager;

    protected override void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
        _InputManager = GetComponent<InputControlManager>();
        _CharaStatus = GetComponent<CharaStatus>();
    }

    protected override void FixedUpdate()
    {
        Move(_InputManager.GetInputVer);
    }

    void Move(Vector2 input)
    {
        //ˆÚ“®
        var move = CalculateMove(input);

        _Rb.linearVelocity = move;

        if(move != Vector3.zero)
        {
            transform.rotation = CalculateRotation(input);
        }
    }
    Vector3 CalculateMove(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y) * _CharaStatus._Speed * GameTime.FixedDeltaTime;
    }

    Quaternion CalculateRotation(Vector2 input)
    {
        //Vector3‚É•ÏŠ·
        var dir = new Vector3(input.x, 0, input.y);

        //Œˆ‚ß‚½‰ñ“]•ûŒü‚ðtargetRotation‚É‘ã“ü‚µ‚Ä‚¢‚é
        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        //‰ñ“]
        return Quaternion.Slerp(transform.rotation, targetRotation, _CharaStatus._RotSpeed * GameTime.FixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        _CurrentHp -= amount;
    }
}
