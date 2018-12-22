using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovePaddles1 : MonoBehaviour {

    [Header("球拍移动速度")]
    public float speedPaddle;

    [Header("球拍的Rigibody")]
    private Rigidbody2D rb2d;

    [Header("球的Rigibody")]
    public Rigidbody2D ballRB2D;

    [Header("板移动方向值")]
    private float inputX;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        //球在球拍的左边向左右，在右边向右移,如果X坐标相同则不移动
        if (ballRB2D.position.x > rb2d.position.x)
        {
            rb2d.velocity = new Vector2(speedPaddle, 0);
          
        }
        else if (ballRB2D.position.x < rb2d.position.x)
        {
            rb2d.velocity = new Vector2(-speedPaddle, 0);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }


    }
}
