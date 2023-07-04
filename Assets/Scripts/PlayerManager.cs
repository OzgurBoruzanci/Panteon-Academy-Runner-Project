using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public float runningSpeed=5;
    public float xSpeed;
    public float limitX=3.8f;
    float _newX;
    float _touchXDelta;

    void Start()
    {
        
        EventManager.PlayerFirstPosition(transform.position);
    }

    void Update()
    {
        SwipeCheck();
    }
    void SwipeCheck()
    {
        _newX = 0;
        _touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x/Screen.width);
            _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            _touchXDelta = Input.GetAxis("Mouse X");
        }
        _newX = transform.position.x + xSpeed * _touchXDelta * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -limitX, limitX);
        EventManager.PlayerPosition(transform.position);
        Move();
    }
    void Move()
    {
        Vector3 _newPosition = new Vector3(_newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = _newPosition;
    }
}
