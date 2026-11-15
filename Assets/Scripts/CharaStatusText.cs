using UnityEngine;
using TMPro;
/// <summary>
/// Plaeyrや敵などのHP表示の操作をするクラス
/// </summary>
public class CharaStatusText : MonoBehaviour 
{
    TextMeshProUGUI _Text;

    void Awake()
    {
        _Text = GetComponent<TextMeshProUGUI>();
    }
    /// <summary>
    /// HP表示の更新
    /// </summary>
    /// <param name="currentHp">現在の体力</param>
    /// <param name="maxHp">最大体力</param>
    public void UpdateHpText(int currentHp, int maxHp)
    {
        _Text.text = currentHp.ToString();
    }
}
