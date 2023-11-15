using UnityEngine;
using UnityEngine.UI;

public class TemplatesWindow : MonoBehaviour
{
    
    [SerializeField]
    private Button _animator;
    [SerializeField]
    private Button _list;
    [SerializeField]
    private Button _timer;
    
    [Space]
    [SerializeField]
    private GameObject _animatorContent;
    [SerializeField]
    private GameObject _scrollViewContent;
    [SerializeField]
    private GameObject _timerContent;

    private void Start()
    {
        _animator.onClick.AddListener(ShowAnimator);
        _list.onClick.AddListener(ShowList);
        _timer.onClick.AddListener(ShowTimer);

        ShowAnimator();
    }
    
    private void ShowAnimator()
    {
        _animatorContent.gameObject.SetActive(true);
        _scrollViewContent.gameObject.SetActive(false);
        _timerContent.gameObject.SetActive(false);
    }

    private void ShowList()
    {
        _animatorContent.gameObject.SetActive(false);
        _scrollViewContent.gameObject.SetActive(true);
        _timerContent.gameObject.SetActive(false);
    }
    
    private void ShowTimer()
    {
        _animatorContent.gameObject.SetActive(false);
        _scrollViewContent.gameObject.SetActive(false);
        _timerContent.gameObject.SetActive(true);
    }
}
