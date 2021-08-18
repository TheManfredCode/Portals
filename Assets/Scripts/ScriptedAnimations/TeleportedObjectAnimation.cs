using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportedObjectAnimation : MonoBehaviour
{
    [SerializeField] private float _enterAnimationDuration;
    [SerializeField] private float _exitAnimationDuration;

    public float EnterAnimationDuration => _enterAnimationDuration;
    public float ExitAnimationDuration => _exitAnimationDuration;

    public void EnterAimation()
    {
        transform.DOScale(0, _enterAnimationDuration);
    }

    public void ExitAnimation()
    {
        transform.DOScale(1, _enterAnimationDuration);
    }
}
