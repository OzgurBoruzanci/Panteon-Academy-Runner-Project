using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    InGameRanking _ig;
    GameObject[] _runners;
    List<RankingSystem> _sortArray= new List<RankingSystem>();

    private void Awake()
    {
        instance = this;
        _runners = GameObject.FindGameObjectsWithTag("Runner");
        _ig = FindObjectOfType<InGameRanking>();
    }
    void Start()
    {
        for (int i = 0; i < _runners.Length; i++)
        {
            _sortArray.Add(_runners[i].GetComponent<RankingSystem>());
        }
    }

    void Update()
    {
        CalculateRank();
    }
    void CalculateRank()
    {
        _sortArray = _sortArray.OrderBy(x => x.distance).ToList();
        _sortArray[0].rank = 1;
        _sortArray[1].rank = 2;
        _sortArray[2].rank = 3;
        _sortArray[3].rank = 4;
        _sortArray[4].rank = 5;
        _sortArray[5].rank = 6;
        _sortArray[6].rank = 7;

        _ig.a = _sortArray[6].name;
        _ig.b= _sortArray[5].name;
        _ig.c= _sortArray[4].name;
        _ig.d= _sortArray[3].name;
        _ig.e= _sortArray[2].name;
        _ig.f= _sortArray[1].name;
        _ig.g= _sortArray[0].name;

    }
}
