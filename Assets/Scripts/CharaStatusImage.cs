using UnityEngine;
using UnityEngine.UI;

public class CharaStatusImage : MonoBehaviour
{
    Image _Image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Image = GetComponent<Image>();
        if(_Image!=null)
        {
            _Image.fillAmount = 1;
        }
    }

    public void UpdateHpGauge(int currentHp,int maxHp)
    {
        _Image.fillAmount = currentHp / maxHp;
    }
}
