using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartMenuAnimation : MonoBehaviour
{
    [SerializeField] private Animator _restartMenuAnimator;
    [SerializeField] private FailureConditions _failureConditions;
    [SerializeField] private ParticleSystem _failEffect;
    [SerializeField] private RestartMenu _restartMenu;
    [SerializeField] private CameraMover _cameraMover;

    [SerializeField] private UnityEvent RestartAnimationCompleted;

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
        _restartMenu.gameObject.SetActive(true);
    }

    private void OnRestart()
    {
        string triggerName = "CloseRestartMenu";

        _restartMenuAnimator.SetTrigger(triggerName);

        StartCoroutine(RestartAnimationCorutine());
    }

    private IEnumerator RestartAnimationCorutine()
    {
        Tween cameraMoveTween = _cameraMover.Move(0);

        yield return cameraMoveTween.WaitForCompletion();

        RestartAnimationCompleted?.Invoke();
    }
}
