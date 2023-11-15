using UnityEngine;
using UnityEngine.UI;

public class AnimatorContent : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Slider _animationSpeed;

    private void Start()
    {
        _animator.speed = _animationSpeed.value;
        _animationSpeed.onValueChanged.AddListener(delegate {ChangeSpeedValue(); });
    }

    private void ChangeSpeedValue()
    {
        _animator.speed = _animationSpeed.value;
    }
}