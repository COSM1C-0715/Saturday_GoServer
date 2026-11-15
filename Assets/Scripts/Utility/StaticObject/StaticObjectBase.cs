using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticObjectBase : MonoBehaviour { }

/// <summary>
/// StaticObject基底クラス
/// </summary>
/// <typeparam name="T">派生クラス型</typeparam>
public class StaticObject<T> : StaticObjectBase where T : StaticObject<T>
{
    /* ========== 変数 ========== */

    /// <summary>
    /// Staticインスタンス
    /// </summary>
    public static T Instance_ { get; private set; }

    /* ========== 関数 ========== */

    /// <summary>
    /// インスタンス生成時実行関数
    /// </summary>
    private void Awake()
    {
        //  インスタンスチェック
        if (Instance_ != null && Instance_ != this)
        {
            Destroy(gameObject);
            return;
        }

        //  自身をDontDestroy化する
        Instance_ = (T)this;
        DontDestroyOnLoad(gameObject);

        //  派生先初期化関数
        Initialize();
    }

    /// <summary>
    /// インスタンス削除時実行関数
    /// </summary>
    private void OnDestroy()
    {
        //  インスタンスチェック
        if (Instance_ != this)
        {
            return;
        }

        //  派生先削除時関数
        OnDestroyInstance();
        Instance_ = null;
    }

    /// <summary>
    /// Active時実行関数
    /// </summary>
    private void OnEnable()
    {
        //  SceneLoad時関数追加
        SceneManager.sceneLoaded += OnLoadedScene;

        //  派生先Active時実行関数
        OnEnableObject();
    }

    /// <summary>
    /// NotActive時実行関数
    /// </summary>
    private void OnDisable()
    {
        //  SceneLoad時関数削除
        SceneManager.sceneLoaded -= OnLoadedScene;

        //  派生先NotActive時実行関数
        OnDisableObject();
    }


    /* ===== 派生先用関数 ===== */

    /// <summary>
    /// インスタンス生成時実行基底関数
    /// </summary>
    protected virtual void Initialize() { }

    /// <summary>
    /// インスタンス削除時実行基底関数
    /// </summary>
    protected virtual void OnDestroyInstance() { }

    /// <summary>
    /// Active時実行基底関数
    /// </summary>
    protected virtual void OnEnableObject() { }

    /// <summary>
    /// NotActive時実行基底関数
    /// </summary>
    protected virtual void OnDisableObject() { }

    /// <summary>
    /// Sceneロード時実行基底関数
    /// </summary>
    /// <param name="scene">ロードしたScene情報</param>
    /// <param name="mode">ロード方法</param>
    protected virtual void OnLoadedScene(
        Scene scene,
        LoadSceneMode mode
        )
    { }
}
