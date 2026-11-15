using UnityEngine;

public class StaticTimeManager : StaticObject<StaticTimeManager>
{
    /* ========== 変数 ========== */

    /// <summary>
    /// ゲーム時間経過速度
    /// </summary>
    private float GameTimeScale_;

    /// <summary>
    /// ポーズフラグ
    /// </summary>
    public bool IsPause_ { get; private set; } = false;

    /* ========== 関数 ========== */

    /* ===== 派生関数 ===== */

    /// <summary>
    /// インスタンス生成時実行派生関数
    /// </summary>
    protected override void Initialize()
    {
        SetGameTimeScale(1.0f);
    }

    /* ===== 独自関数 ===== */

    /// <summary>
    /// ゲーム時間経過速度変更関数
    /// </summary>
    /// <param name="scale">変更する速度</param>
    public void SetGameTimeScale(
        float scale
        )
    {
        GameTimeScale_ = scale;
        UnityEngine.Time.timeScale = scale;
        Debug.Log($"Change Time Scale  = {GameTimeScale_}");
    }

    /// <summary>
    /// ポーズセット関数
    /// </summary>
    /// <param name="pause">ポーズフラグ</param>
    public void SetPause(
        bool pause
        )
    {
        if (IsPause_ == pause) { return; }

        IsPause_ = pause;
        UnityEngine.Time.timeScale = IsPause_ ? 0.0f : GameTimeScale_;
    }
}
