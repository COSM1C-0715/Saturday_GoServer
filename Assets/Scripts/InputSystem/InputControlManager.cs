using UnityEngine;
using UnityEngine.InputSystem;

public class InputControlManager : MonoBehaviour
{
    //入力値の取得
    [SerializeField]
    Vector2 _InputVer;

    /// <summary>
    /// 外部から入力値を取得するためのプロパティ変数
    /// </summary>
    public Vector2 GetInputVer => _InputVer;

    //InputAction
    private InputAction _MoveAction;

    private InputAction _AttackAction;
    //Component取得
    AttackInput _AttackInput;
    void Awake()
    {
        //InputActionの取得
        _MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");
        _AttackAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Attack");

        _AttackInput = GetComponent<AttackInput>();
    }

    void OnEnable()
    {
        _AttackAction.performed += _ => _AttackInput.Attack();
    }

    void OnDisable()
    {
        _AttackAction.performed -= _ => _AttackInput.Attack();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //移動入力取得
        if (_MoveAction != null)
        {
            _InputVer = _MoveAction.ReadValue<Vector2>();
        }
    }
}
