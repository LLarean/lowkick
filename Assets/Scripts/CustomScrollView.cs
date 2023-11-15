using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour
{
    [SerializeField]
    private CustomVerticalGroup _customVerticalGroup;
    [SerializeField]
    private ScrollRect _scrollRect;
    [SerializeField]
    private RectTransform _rectTransform;

    [Space]
    [SerializeField]
    private float _minimumInertia = 40f;
    
    private Coroutine _coroutine;
    private bool _isScrolling = false;

    private void Start()
    {
        _customVerticalGroup.Initialize();
    }

    private void OnEnable()
    {
        DisableTimer();
        
        _coroutine = StartCoroutine(LimitScrollView());
    }

    private void OnDisable()
    {
        DisableTimer();
    }

    private void DisableTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator LimitScrollView()
    {
        while(gameObject.activeSelf == true)
        {
            LimitScrolling();
            LimitInertia();
        
            _customVerticalGroup.RefreshList(_scrollRect.content.anchoredPosition.y);
            // yield return new WaitForEndOfFrame();
            yield return null;
        }
    }

    private void LimitScrolling()
    {
        float minimumY = 0;

        if (_scrollRect.content.localPosition.y < minimumY)
        {
            Vector3 pos = _scrollRect.content.localPosition;
            pos.y = minimumY;
            _scrollRect.velocity = Vector2.zero;
            _scrollRect.content.localPosition = pos;
        }

        float maximumY = _customVerticalGroup.Spacing * _customVerticalGroup.TotalItems - _rectTransform.sizeDelta.y;

        if (_scrollRect.content.localPosition.y > maximumY)
        {
            Vector3 pos = _scrollRect.content.localPosition;
            pos.y = maximumY;
            _scrollRect.velocity = Vector2.zero;
            _scrollRect.content.localPosition = pos;
        }
    }

    private void LimitInertia()
    {
        if (_scrollRect.velocity.magnitude < _minimumInertia && _isScrolling)
        {
            _scrollRect.velocity = Vector2.zero;
            _isScrolling = false;
        }
        else if (_scrollRect.velocity.magnitude > 0)
        {
            _isScrolling = true;
        }
    }
}