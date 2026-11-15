using UnityEngine;
/// <summary>
/// それぞれのUIの操作をするクラス
/// </summary>
public class UIManagement : MonoBehaviour
{
    [SerializeField]
    CharaStatusImage _Image;

    [SerializeField]
    CharaStatusText _Text;

    [SerializeField]
    Player _Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Player.UIEvent = PlayerUIUpdate;
        PlayerUIUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
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
