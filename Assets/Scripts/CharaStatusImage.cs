using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Plaeyrや敵などのHPゲージの操作をするクラス
/// </summary>
public class CharaStatusImage : MonoBehaviour
{
    Image _Image;
    void Awake()
    {
        _Image = GetComponent<Image>();
    }
    /// <summary>
    /// HPの更新
    /// </summary>
    /// <param name="currentHp">現在の体力</param>
    /// <param name="maxHp">最大体力</param>
    public void UpdateHpGauge(int currentHp, int maxHp)
    {
        _Image.fillAmount = (float)currentHp / maxHp;
    }
}
