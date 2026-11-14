using UnityEngine;
using static TimeUtility;

public class Player : Character
{
    Rigidbody Rb;

    InputControlManager InputManager;

    CharaStatus CharaStatus;

    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        InputManager = GetComponent<InputControlManager>();
        CharaStatus = GetComponent<CharaStatus>();
    }

    protected override void FixedUpdate()
    {
        Move(InputManager.GetInputVer);
    }

    void Move(Vector2 input)
    {
        //ˆÚ“®
        var move = CalculateMove(input);

        Rb.linearVelocity = move;

        if(move != Vector3.zero)
        {
            transform.rotation = CalculateRotation(input);
        }
    }
    Vector3 CalculateMove(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y) * CharaStatus._Speed * GameTime.FixedDeltaTime;
    }

    Quaternion CalculateRotation(Vector2 input)
    {
        //Vector3‚É•ÏŠ·
        var dir = new Vector3(input.x, 0, input.y);

        //Œˆ‚ß‚½‰ñ“]•ûŒü‚ðtargetRotation‚É‘ã“ü‚µ‚Ä‚¢‚é
        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        //‰ñ“]
        return Quaternion.Slerp(transform.rotation, targetRotation, CharaStatus._RotSpeed * GameTime.FixedDeltaTime);
    }
}
