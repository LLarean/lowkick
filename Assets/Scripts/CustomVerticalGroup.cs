using System.Collections.Generic;
using UnityEngine;

public class CustomVerticalGroup : MonoBehaviour
{
    [SerializeField]
    private Item _item;
    [SerializeField]
    private RectTransform _content;
    
    [Space]
    [SerializeField]
    private int _totalItems = 100;
    [SerializeField]
    private int _bufferSize = 10;

    [Space]
    [SerializeField]
    private float _spacing = 100f;
    
    private List<Item> _items = new List<Item>();
    
    private int _startIndex = 0;
    private int _endIndex = 0;

    public int TotalItems => _totalItems;
    public float Spacing => _spacing;

    public void Initialize()
    {
        for (int i = 0; i < _totalItems && i < _bufferSize; i++)
        {
            Item newItem = Instantiate(_item, _content);
            newItem.RectTransform.anchoredPosition = new Vector2(0, i * _spacing);
            
            var itemNumber = i + 1;
            newItem.SetLabel("Item " + itemNumber);
            
            _items.Add(newItem);
            _endIndex++;
        }
    }
    
    public void RefreshList(float scrollPosY)
    {
        int newStartIndex = Mathf.FloorToInt(scrollPosY / _spacing);
        newStartIndex = Mathf.Clamp(newStartIndex, 0, _totalItems - 1);
        
        int newEndIndex = newStartIndex + _bufferSize - 1;
        newEndIndex = Mathf.Clamp(newEndIndex, 0, _totalItems - 1);

        if (newStartIndex != _startIndex || newEndIndex != _endIndex)
        {
            _startIndex = newStartIndex;
            _endIndex = newEndIndex;
            UpdateVisibleItems();
        }
    }

    private void UpdateVisibleItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (i + _startIndex < _totalItems && i + _startIndex >= 0)
            {
                _items[i].RectTransform.anchoredPosition = new Vector2(0, -(i + _startIndex) * _spacing);
                
                var itemNumber = i + _startIndex + 1;
                _items[i].SetLabel("Item " + itemNumber);
                
                _items[i].gameObject.SetActive(true);
            }
            else
            {
                _items[i].gameObject.SetActive(false);
            }
        }
    }
}