using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

/// <summary>
/// 小球跳动
/// </summary>
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;

    public string currentColor;
    public SpriteRenderer sr;

    public Color blueColor;
    public Color yellowColor;
    public Color pinkColor;
    public Color purpleColor;
    private bool firstBegin = true;

    private void Start()
    {
        SetRandomColor();
        rb.gravityScale = 0;
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "bule";
                sr.color = blueColor;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = yellowColor;
                break;
            case 2:
                currentColor = "pink";
                sr.color = pinkColor;
                break;
            case 3:
                currentColor = "purple";
                sr.color = purpleColor;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0))
        {
            if (firstBegin)
            {
                rb.gravityScale = 3;
                firstBegin = false;
            }

            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //碰撞的对象col
        if (col.CompareTag("color changer"))
        {
            SetRandomColor();
            Destroy(col);
            return;
        }

        if (!col.CompareTag(currentColor))
        {
            //回到出生点
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (col.CompareTag("win point"))
        {
            SceneManager.LoadScene("Win");
        }
    }
}