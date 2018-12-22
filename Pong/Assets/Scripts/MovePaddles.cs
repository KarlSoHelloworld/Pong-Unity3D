using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePaddles : MonoBehaviour {

    [Header("球拍移动速度")]
    public float speedPaddle;

    [Header("各种组件")]
    public Rigidbody2D rb2d;

    [Header("玩家输入值")]
    private float inputX;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	

    void Update()
    {
        inputX=Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb2d.velocity = inputX * new Vector2(speedPaddle, 0);

    }
}
