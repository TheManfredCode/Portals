using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class WinAnimation : MonoBehaviour
{
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private ParticleSystem _winParticles;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private float _moveCameraDelay;
    [SerializeField] private Transform[] _objectsToMinimize;

    [SerializeField] private UnityEvent WinAnimationCompleted;

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
        if(_winParticles != null)
            _winParticles.Play();

        StartCoroutine(WinAnimationCoroutine());
    }

    private IEnumerator WinAnimationCoroutine()
    {
        foreach (Transform obj in _objectsToMinimize)
            obj.DOScale(0, 0.5f);

        Tween cameraMoveTween = _cameraMover.Move(_moveCameraDelay);

        yield return cameraMoveTween.WaitForCompletion();

        WinAnimationCompleted?.Invoke();
    }
}
