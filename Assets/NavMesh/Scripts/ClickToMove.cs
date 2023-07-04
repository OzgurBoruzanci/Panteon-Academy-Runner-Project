using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent _m_Agent;
    RaycastHit _m_HitInfo = new RaycastHit();

    private void Start()
    {
        _m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin,ray.direction,out _m_HitInfo))
            {
                _m_Agent.destination = _m_HitInfo.point;
            }
        }
        
    }
}
