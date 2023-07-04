using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinisPointManager : MonoBehaviour
{
    bool firstCome = true;
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
        firstCome = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (firstCome)
        {
            firstCome = false;
            EventManager.FirstCome(other.name);
        }
    }
}
