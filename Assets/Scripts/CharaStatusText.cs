using UnityEngine;
using UnityEngine.UI;

public class CharaStatusText : MonoBehaviour
{
    Text _Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Text = GetComponent<Text>();
    }
    public void NameText(string name)
    {
        _Text.text = string.Format("{0}", name);
    }
}
