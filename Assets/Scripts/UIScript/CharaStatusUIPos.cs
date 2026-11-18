using UnityEngine;

public class CharaStatusUIPos : MonoBehaviour
{
    RectTransform rect;

    [SerializeField]
    Vector3 _OffSet = new Vector3(0.0f,2.0f,0.0f);

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void UpdateRectTransform(Vector3 pos)
    {
        Vector3 uiPos = _OffSet + pos;

        rect.position = Camera.main.WorldToScreenPoint(uiPos);
    }
}
