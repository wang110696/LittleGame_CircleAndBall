using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 圈转动
/// </summary>
public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 100f;

    private void Update()
    {
        //每秒转100度
        transform.Rotate(0f,0f,rotateSpeed*Time.deltaTime);
    }

}
