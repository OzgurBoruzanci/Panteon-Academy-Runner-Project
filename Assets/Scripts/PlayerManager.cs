using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float runningSpeed=5;
    public float xSpeed;
    public float limitX=3.8f;
    float newX;
    float touchXDelta;
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
        newX = 0;
        touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x/Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
        EventManager.PlayerPosition(transform.position);
        Move();
    }
    void Move()
    {
        Vector3 _newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = _newPosition;
    }
}
