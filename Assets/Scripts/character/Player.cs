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
    }
    private Vector3 CalculateMove(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y) * CharaStatus.Speed * GameTime.FixedDeltaTime;
    }
}
