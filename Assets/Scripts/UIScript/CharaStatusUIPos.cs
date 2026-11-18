using UnityEngine;

public class CharaStatusUIPos : MonoBehaviour
{
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void UpdateRectTransform(Vector3 pos)
    {
        rect.position = Camera.main.WorldToScreenPoint(pos);
    }
}
