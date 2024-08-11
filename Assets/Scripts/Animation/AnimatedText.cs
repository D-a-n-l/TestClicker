using UnityEngine;
using DG.Tweening;
using TMPro;
using NTC.Pool;

public class AnimatedText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private string _maskText;

    [Space(5)]
    [SerializeField]
    private float _offsetY;

    [SerializeField]
    private float _duration;

    private Vector3 _defaultPosition;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    private void OnEnable()
    {
        StartAnimation();
    }

    private void OnDisable()
    {
        transform.position = _defaultPosition;

        _text.color = Color.white;
    }

    public void Init(int value)
    {
        _text.text = $"{_maskText}{value}";
    }

    public void StartAnimation()
    {
        DOTween.Sequence()
            .Append(transform.DOMoveY(transform.position.y + _offsetY, _duration))
            .Append(_text.DOFade(0, _duration))
            .OnComplete(() => NightPool.Despawn(gameObject));
    }
}