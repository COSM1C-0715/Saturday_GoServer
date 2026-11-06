using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        
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
