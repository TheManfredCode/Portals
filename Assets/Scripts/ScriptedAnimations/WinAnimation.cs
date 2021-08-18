using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(ISceneLoader))]
public class WinAnimation : MonoBehaviour
{
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private ParticleSystem _winParticles;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Image _winImage;
    [SerializeField] private float _winImageShowPositionY;
    [SerializeField] private float _winImageMoveDuration;
    [SerializeField] private float _winImageShowTime;
    
    private ISceneLoader _loadNextScene;
    private Vector3 _winImageStartPosition;

    private void OnEnable()
    {
        _winCondition.Win += OnWin;
    }

    private void OnDisable()
    {
        _winCondition.Win -= OnWin;
    }

    private void Start()
    {
        _loadNextScene = GetComponent<ISceneLoader>();
        _winImageStartPosition = _winImage.transform.position;
    }

    public void OnWin()
    {
        if(_winParticles != null)
            _winParticles.Play();

        StartCoroutine(WinAnimationCoroutine());
    }

    private IEnumerator WinAnimationCoroutine()
    {
        Sequence winImageSequence = DOTween.Sequence();

        winImageSequence.Append(_winImage.transform.DOMoveY(_winImageShowPositionY, _winImageMoveDuration));
        winImageSequence.Append(_winImage.transform.DOMoveY(_winImageStartPosition.y, _winImageMoveDuration).SetDelay(_winImageShowTime));

        float cameraMoveDelay = _winImageMoveDuration + _winImageShowTime;
        Tween cameraMoveTween = _cameraMover.Move(cameraMoveDelay);

        yield return cameraMoveTween.WaitForCompletion();

        _loadNextScene.Load();
    }
}
