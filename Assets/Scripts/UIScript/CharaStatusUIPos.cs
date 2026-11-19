using UnityEngine;

public class CharaStatusUIPos : MonoBehaviour
{
    RectTransform rect;

    [SerializeField]
    Vector3 _OffSet = new Vector3(0.0f,2.0f,0.0f);

    public bool IsActive => gameObject.activeSelf;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    /// <summary>
    /// 敵のHPを表示させるUIが敵の上に来るように調整する関数
    /// </summary>
    /// <param name="pos">敵のポジション</param>
    public void UpdateRectTransform(Vector3 pos)
    {
        Vector3 uiPos = _OffSet + pos;

        rect.position = Camera.main.WorldToScreenPoint(uiPos);
    }
    /// <summary>
    /// このクラスをつけているUIを表示・非表示させるためだけの関数
    /// </summary>
    /// <param name="active"></param>
    public void UISetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
