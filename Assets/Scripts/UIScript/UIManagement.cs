using UnityEngine;
/// <summary>
/// それぞれのUIの操作をするクラス
/// </summary>
public class UIManagement : MonoBehaviour
{
    CharaStatusImage _Image;

    CharaStatusText _Text;

    CharaStatusUIPos _UIPos;

    Player _Player;

    Enemy _Enemy;

    void Awake()
    {
        _Image = GameObject.Find("PlayerStatusUI").transform.GetChild(1).GetComponent<CharaStatusImage>();
        _Text = GameObject.Find("PlayerStatusUI").transform.GetChild(2).GetComponent<CharaStatusText>();
        _Player = GameObject.Find("Player").transform.GetChild(0).GetComponent<Player>();
        _Enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        _UIPos = GameObject.Find("EnemyStatus").GetComponent<CharaStatusUIPos>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_Player != null)
        {
            _Player.UIEvent = UIUpdate<Player>;
        }
        if (_Image != null && _Text != null)
        {
            UIUpdate<Player>(_Player.CurrentHp,_Player.MaxHp);
        }
    }

    void FixedUpdate()
    {
        if(_Enemy != null)
        {
            _UIPos.UpdateRectTransform(_Enemy.transform.position);
        }
    }
    /// <summary>
    /// HPのUIの更新
    /// </summary>
    /// <typeparam name="T">Characterを継承しているクラス</typeparam>
    /// <param name="current">現在体力</param>
    /// <param name="max">最大体力</param>
    void UIUpdate<T>(float current,float max)
    {
        if(typeof(T) == typeof(Player))
        {
            _Image.UpdateHpGauge(current, max);
            _Text.UpdateHpText(current, max);
        }
    }
}
