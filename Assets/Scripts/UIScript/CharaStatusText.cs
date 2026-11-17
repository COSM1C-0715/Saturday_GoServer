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
    /// <param name="current">現在の体力</param>
    /// <param name="max">最大体力</param>
    public void UpdateHpText(float current, float max)
    {
        _Text.text = string.Format("{1}/{2}",string.Empty,current,max);
    }
}
