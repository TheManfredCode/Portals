using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIWinAnimation : MonoBehaviour
{
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private GameObject[] _winPanels;
    [SerializeField] private ParticleSystem _winParicles;

    private void OnEnable()
    {
        _winCondition.Win += OnWin;
    }
    private void OnDisable()
    {
        _winCondition.Win -= OnWin;
    }

    private void OnWin()
    {
        if(_winParicles != null)
            _winParicles.Play();

        foreach (var item in _winPanels)
            item.SetActive(true);
    }
}
