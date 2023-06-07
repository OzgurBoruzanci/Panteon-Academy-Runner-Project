using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 _playerPosition;
    Vector3 _playerFirstPosition;
    Vector3 _distance;
    public GameObject lookPosition;

    private void OnEnable()
    {
        EventManager.PlayerFirstPosition += PlayerFirstPosition;
        EventManager.PlayerPosition += PlayerPosition;
    }
    private void OnDisable()
    {
        EventManager.PlayerFirstPosition -= PlayerFirstPosition;
        EventManager.PlayerPosition -= PlayerPosition;
    }
    void PlayerFirstPosition(Vector3 playerFirstPos)
    {
        _playerFirstPosition= playerFirstPos;
    }
    void PlayerPosition(Vector3 playerPos)
    {
        _playerPosition = playerPos;
    }

    void Start()
    {
        _distance = _playerFirstPosition - transform.position;
    }
    private void LateUpdate()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, _playerPosition - _distance, 5 * Time.deltaTime);
        transform.LookAt(lookPosition.transform.position);
    }
}
