using UnityEngine;
/// <summary>
/// それぞれのUIの操作をするクラス
/// </summary>
public class UIManagement : MonoBehaviour
{
    CharaStatusImage[] _Image = new CharaStatusImage[2];

    CharaStatusText _Text = null;

    CharaStatusUIPos _UIPos = null;

    Player _Player = null;

    [SerializeField]
    float _Distance = 1.0f;

    void Awake()
    {
        _Image[0] = GameObject.Find("PlayerStatusUI").transform.GetChild(1).GetComponent<CharaStatusImage>();
        _Image[1] = GameObject.Find("EnemyStatus").transform.GetChild(1).GetComponent<CharaStatusImage>();
        _Text = GameObject.Find("PlayerStatusUI").transform.GetChild(2).GetComponent<CharaStatusText>();
        _Player = GameObject.Find("Player").transform.GetChild(0).GetComponent<Player>();
        _UIPos = GameObject.Find("EnemyStatus").GetComponent<CharaStatusUIPos>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_Player != null)
        {
            _Player.UIEvent = UIUpdate<Player>;
        }
        if (_Image[0] != null && _Text != null)
        {
            UIUpdate<Player>(_Player.CurrentHp,_Player.MaxHp);
        }
    }

    void FixedUpdate()
    {
        if(_Player.Chara != null)
        {
            _UIPos.UISetActive(true);
            _UIPos.UpdateRectTransform(_Player.Chara.transform.position);
            UIUpdate<Enemy>(_Player.Chara.CurrentHp,_Player.Chara.MaxHp);
        }
        else
        {
            _UIPos.UISetActive(false);
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
            _Image[0].UpdateHpGauge(current, max);
            _Text.UpdateHpText(current, max);
        }
        else if(typeof(T) == typeof(Enemy))
        {
            _Image[1].UpdateHpGauge(current, max);
        }
    }
}
