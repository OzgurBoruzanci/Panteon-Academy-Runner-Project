using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float runningSpeed=5;
    private void Awake()
    {
        EventManager.PlayerFirstPosition(transform.position);
    }
    void Start()
    {
        
        
    }

    void Update()
    {
        EventManager.PlayerPosition(transform.position);
        Move();
    }

    void Move()
    {
        Vector3 _newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = _newPosition;
    }
}
