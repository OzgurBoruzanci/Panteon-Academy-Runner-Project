using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    public float spped = 1f;
    public float strenght = 2.5f;
    float _randomOffset;
    
    void Start()
    {
        _randomOffset=Random.Range(-2.5f,2.5f);
    }

    void Update()
    {
        Vector3 pos= transform.position;
        pos.x = Mathf.Sin(Time.deltaTime * spped * _randomOffset) * strenght;
        transform.position=pos;
    }
}
