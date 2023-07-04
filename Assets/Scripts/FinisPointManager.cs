using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinisPointManager : MonoBehaviour
{
    bool _firstCome = true;
    private void OnEnable()
    {
        EventManager.RestartBtn += RestartBtn;
    }
    private void OnDisable()
    {
        EventManager.RestartBtn -= RestartBtn;
    }
    void RestartBtn()
    {
        _firstCome = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_firstCome)
        {
            _firstCome = false;
            EventManager.FirstCome(other.name);
        }
    }
}
