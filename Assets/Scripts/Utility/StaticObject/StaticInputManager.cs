using UnityEngine;
using UnityEngine.InputSystem;

public static class MapName
{
    public const string Player = "Player";
    public const string UI = "UI";
}

/// <summary>
/// InputManagerクラス
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class StaticInputManager : StaticObject<StaticInputManager>
{
    /* ========== 変数 ========== */

    /// <summary>
    /// PlayerInput
    /// </summary>
    private PlayerInput Input_;

    /* ========== 関数 ========== */

    /* ===== 派生関数 ===== */

    /// <summary>
    /// インスタンス生成時実行派生関数
    /// </summary>
    protected override void Initialize()
    {
        Input_ = GetComponent<PlayerInput>();
        if (Input_ == null)
        {
            Debug.LogError("StaticInputManager PlayerInput Not Found");
        }
    }


    /* ===== 独自関数 ===== */

    /// <summary>
    /// InputAction取得関数
    /// </summary>
    /// <param name="mapName">取得先アクションマップ名</param>
    /// <param name="actionName">取得したいアクション名</param>
    /// <returns>取得したアクション... 無かったら [ null ]</returns>
    public InputAction GetInputAction(
        string mapName,
        string actionName
        )
    {
        //  PlayerInput確認
        if (!HasInput())
        {
            return null;
        }

        //  ActionMap取得
        InputActionMap map = Input_.actions.FindActionMap(mapName);
        if (map == null)
        {
            Debug.LogError($"InputActionMap Not Found : {mapName}");
            return null;
        }

        //  Action取得
        InputAction action = map.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError($"InputAction Not Found : {mapName} / {actionName}");
            return null;
        }

        return action;
    }

    /// <summary>
    /// アクションマップ変更関数
    /// </summary>
    /// <param name="mapName">変更先アクションマップ名</param>
    public void ChangeActionMap(
        string mapName
        )
    {
        //  PlayerInput確認
        if (!HasInput())
        {
            return;
        }

        // ActionMap確認
        InputActionMap map = Input_.actions.FindActionMap(mapName);
        if (map == null)
        {
            Debug.LogError($"InputActionMap Not Found : {mapName}");
            return;
        }

        //  ActionMap変更
        Input_.SwitchCurrentActionMap(mapName);

    }

    /// <summary>
    /// PlayerInput参照確認関数
    /// </summary>
    /// <returns>参照があるなら [ True ]</returns>
    private bool HasInput()
    {
        return Input_ != null;
    }

}
