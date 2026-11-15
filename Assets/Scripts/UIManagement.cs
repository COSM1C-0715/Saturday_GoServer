using UnityEngine;
/// <summary>
/// それぞれのUIの操作をするクラス
/// </summary>
public class UIManagement : MonoBehaviour
{
    CharaStatusImage _Image;

    CharaStatusText _Text;

    Player _Player;

    void Awake()
    {
        _Image = GameObject.Find("PlayerStatusUI").transform.GetChild(1).GetComponent<CharaStatusImage>();
        _Text = GameObject.Find("PlayerStatusUI").transform.GetChild(2).GetComponent<CharaStatusText>();
        _Player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_Player!=null)
        {
            _Player.UIEvent = PlayerUIUpdate;
        }
        if(_Image!=null&&_Text!=null)
        {
            PlayerUIUpdate();
        }        
    }
    /// <summary>
    /// PlayerのHPのUIの更新
    /// </summary>
    void PlayerUIUpdate()
    {
        _Image.UpdateHpGauge(_Player.CurrentHp,_Player.MaxHp);
        _Text.UpdateHpText(_Player.CurrentHp, _Player.MaxHp);
    }
}
