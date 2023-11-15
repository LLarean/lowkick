using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] 
    private RectTransform _rectTransform;
    [SerializeField] 
    private TMP_Text _label;

    public RectTransform RectTransform => _rectTransform;

    public void SetLabel(string value)
    {
        _label.text = value;
    }
}