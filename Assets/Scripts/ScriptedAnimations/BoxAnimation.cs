using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxAnimation : MonoBehaviour
{
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Transform _cover;

    private void OnEnable()
    {
        _winCondition.Win += OnWin;
    }

    private void OnDisable()
    {
        _winCondition.Win -= OnWin;
    }

    public void OnWin()
    {
        Sequence animationSequence = DOTween.Sequence();

        animationSequence.Append(_cover.DORotate(new Vector3(-100, 0), 0.3f, RotateMode.LocalAxisAdd).SetDelay(0.5f));
        animationSequence.Append(transform.DOScale(0.3f, 0.2f).SetLoops(2, LoopType.Yoyo));
        animationSequence.Append(transform.DORotate(new Vector3(720, 0), 0.5f, RotateMode.LocalAxisAdd));
        animationSequence.Append(transform.DOScale(0, _animationDuration));
    }
}
