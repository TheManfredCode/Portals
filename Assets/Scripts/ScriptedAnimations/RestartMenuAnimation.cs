using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartMenuAnimation : MonoBehaviour
{
    [SerializeField] private FailureConditions _failureConditions;
    [SerializeField] private ParticleSystem _failEffect;
    [SerializeField] private RestartMenu _restartMenu;
    [SerializeField] private Transform[] _obectsToAnimate;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private float _restartAnimationDuration;
    [SerializeField] private float _restartMenuShowPositionY;

    private Vector3 _restartMenuStartPosition;

    [SerializeField] private UnityEvent RestartAnimationCompleted;

    private void Start()
    {
        _restartMenuStartPosition = _restartMenu.transform.position;
    }

    private void OnEnable()
    {
        _failureConditions.Failed += OnFailed;
        _restartMenu.Restart += OnRestart;
    }

    private void OnDisable()
    {
        _failureConditions.Failed -= OnFailed;
        _restartMenu.Restart -= OnRestart;
    }

    private void OnFailed()
    {
        _failEffect.Play();

        float showFailImageDelay = 1;
        _restartMenu.transform.DOMoveY(_restartMenuShowPositionY, _restartAnimationDuration).SetDelay(showFailImageDelay);
    }

    private void OnRestart()
    {
        StartCoroutine(RestartAnimationCorutine());
    }

    private IEnumerator RestartAnimationCorutine()
    {
        foreach (Transform animatedObject in _obectsToAnimate)
            animatedObject.DOScale(0, _restartAnimationDuration);

        _cameraMover.Move(0);

        Tween restartMenuTween = _restartMenu.transform.DOMoveY(_restartMenuStartPosition.y, _restartAnimationDuration);

        yield return restartMenuTween.WaitForCompletion();

        RestartAnimationCompleted?.Invoke();
    }
}
