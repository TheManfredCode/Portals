using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event UnityAction Restart;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        Restart?.Invoke();
    }
}
