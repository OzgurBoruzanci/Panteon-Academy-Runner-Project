using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent opponentAgent;
    public GameObject target;
    void Start()
    {
        opponentAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        opponentAgent.SetDestination(target.transform.position);
    }
}
