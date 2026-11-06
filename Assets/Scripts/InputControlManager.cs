using UnityEngine;
using UnityEngine.InputSystem;

public class InputControlManager : MonoBehaviour
{
    //入力値の取得
    Vector2 InputVer;

    /// <summary>
    /// 外部から入力値を取得するためのプロパティ変数
    /// </summary>
    public Vector2 GetInputVer => InputVer;

    //InputAction
    private InputAction MoveAction;
    void Awake()
    {
        //InputActionの取得
        MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //移動入力取得
        if (MoveAction != null)
        {
            InputVer = MoveAction.ReadValue<Vector2>();
        }
    }
}
