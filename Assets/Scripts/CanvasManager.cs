using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI finishScore;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI wonText;
    public GameObject youWin;
    public GameObject youLose;
    public GameObject inGameRanking;
    float _score = 0;
    string _firstCmNm;
    private void OnEnable()
    {
        EventManager.AddCoin += AddCoin;
        EventManager.FirstCome += FirstCome;
        EventManager.EndGame += EndGame;
    }
    private void OnDisable()
    {
        EventManager.AddCoin -= AddCoin;
        EventManager.FirstCome -= FirstCome;
        EventManager.EndGame -= EndGame;
    }
    void FirstCome(string firstCm)
    {
        _firstCmNm = firstCm;
        if (firstCm=="Player")
        {
            youWin.gameObject.SetActive(true);
        }
        else
        {
            youLose.gameObject.SetActive(true);
        }
    }
    void EndGame()
    {
        endPanel.gameObject.SetActive(true);
        finishScore.text = "Score: " + _score.ToString();
        coinText.gameObject.SetActive(false);
        inGameRanking.gameObject.SetActive(false);
        wonText.text = "Winner " + _firstCmNm;
        
    }
    public void AddCoin()
    {
        _score++;
        coinText.text = "Score: " + _score.ToString();
    }
    public void RestartBtn()
    {
        EventManager.RestartBtn();
        SceneManager.LoadScene("SampleScene");
    }
}