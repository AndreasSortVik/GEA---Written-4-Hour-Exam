using System;
using UnityEngine;
using UnityEngine.Splines;

public class AICubeMovement : MonoBehaviour
{
    private SplineAnimate _splineAnimateScript;
    private float _time;

    private int _lapAmount = 0;
    private float _speed;

    private void Awake()
    {
        _splineAnimateScript = GetComponent<SplineAnimate>();
    }

    public void PauseAnimation()
    {
        _splineAnimateScript.Pause();
    }

    public void PlayAnimation()
    {
        _splineAnimateScript.Play();
    }

    public void UpdateLapInfo()
    {
        _lapAmount++;
        print("Lap number: " + _lapAmount);
    }
}
