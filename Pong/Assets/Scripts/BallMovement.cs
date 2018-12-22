using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    [Header("各种组件")]
    private Rigidbody2D rb2d;
    public AudioSource collisionAudio;
    public AudioSource winAudio;
    public AudioSource loseAudio;

    [Header("玩家、敌人分数")]
    private int scorePlayer;
    private int scoreEnemy;

    [Header("分数Text")]
    public Text topText;
    public Text bottomText;
    public Text countdownText;

    [Header("游戏结束w文本")]
    public Text gameOverText;

    [Header("水平速度")]
    public float speedX;

    [Header("垂直速度")]
    public float speedY;


    void Start()
    {
        //获取rigibody2D组件
        rb2d = GetComponent<Rigidbody2D>();        

        //初始化数值
        scorePlayer = 0;
        scoreEnemy = 0;
        UpDateScoreText();

        //延迟3秒发球
        Invoke("ShootBall",3);        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //播放碰撞声音
        collisionAudio.Play();

        //当小球碰到 顶部 时，检查当前得分是否游戏结束
        if (other.gameObject.CompareTag("Top"))
        {
            scorePlayer += 1;
            UpDateScoreText();
            CheckGameOver();
        }
        //当小球碰到 底部 时，检查当前得分是否游戏结束
        else if (other.gameObject.CompareTag("Bottom"))
        {
            scoreEnemy += 1;
            UpDateScoreText();
            CheckGameOver();
        }

        //碰撞时锁定小球的速度
        LockSpeed(); 

    }

    #region 分数变化检查是否游戏结束，结束调用GameOver。没结束重新发球。
    private void CheckGameOver()
    {
        //当敌人得分到达5，玩家失败，游戏分数归零，游戏结束
        if (scoreEnemy >= 5)
        {
            //播放失败游戏声音
            loseAudio.Play();

            //游戏结束
            GameOver();
        }
        //重新发球
        else
        {
            ReshootBall();
        }
        //当玩家得分到达5，玩家胜利，游戏分数归零，游戏结束
        if (scorePlayer >= 5)
        {
            winAudio.Play();
            GameOver();
        }
        //重新发球
        else
        {
            ReshootBall();
        }
    }
    #endregion

    #region 倒计时
    IEnumerator CountDown()
    {
        //设置等待时长为3秒
        int totalTime = 3;

        //倒计时，当时间为0时结束倒计时
        while (totalTime >= 0)
        {
            //更新倒计时Text
            countdownText.text = totalTime.ToString();

            //延时1秒执行
            yield return new WaitForSeconds(1);
            Debug.Log(totalTime);
            //倒计时-1
            totalTime--;
        }
        yield return new WaitForSeconds((float)0.1);
        countdownText.text = "";
    }
    #endregion

    #region 操作GameOverText
    void ShowGameOverText()
    {
        //显示游戏结束提示You Lose或者You Win
        if (scoreEnemy >= 5)
        {
            gameOverText.text = "You Lose!!!";
        }
        else if (scorePlayer >= 5)
        {
            gameOverText.text = "You Win!!!";
        }
        else
        { }
    }
    void HideGameOverText()
    {
        gameOverText.text = "";
    }
    #endregion

    #region 游戏结束
    void GameOver()
    {
        rb2d.position = Vector2.zero;


        //显示游戏结束Text
        ShowGameOverText();

        //归零分数
        scoreEnemy = 0;
        scorePlayer = 0;
      

        //归零分数显示
        topText.text = "SCORE:0";
        bottomText.text = "SCORE:0";

        //3秒后关闭游戏结束Text
        Invoke("HideGameOverText",3);
        
    }
    #endregion

    #region 延迟3秒在原点重新开球
    private void ReshootBall()
    {
        //球的位子，速度归零
        rb2d.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;

        //显示倒计时TEXT
        StartCoroutine(CountDown());

        //延迟3秒重新发球
        Invoke("ShootBall", 3);        
    }
    #endregion

    #region 锁定球的运动速度
    void LockSpeed()
    {
        //根据当前方向设定当前速度为speed
        rb2d.velocity = new Vector2(LeftOrRight(), UpOrDown());
    }
    #endregion

    #region 确定球的运行方向 左右/上下
    float LeftOrRight()
    {
        //如果x大于0，球向右移动，返回速度为正x
        if (rb2d.velocity.x > 0)
        {
            return speedX;
        }
        //如果x小于0，球向左游动，返回速度为负x
        else if (rb2d.velocity.x < 0)
        {
            return -speedX;
        }
        //速度为0，处于发球阶段，返回0
        else
        {
            return 0;
        }
    }

    float UpOrDown()
    {
        //如果y大于0，球向上移动，返回速度为正y
        if (rb2d.velocity.y > 0)
        {
            return speedY;
        }
        //如果y小于0，球向下游动，返回速度为负y
        else if (rb2d.velocity.y<0)
        {
            return -speedY;
        }
        //速度为0，处于发球阶段，返回0
        else
        {
            return 0;
        }
    }
    #endregion

    #region 随机发射小球，向上或向下
    void ShootBall()
    {        
        System.Random random = new System.Random();
        //当小球速度为0时
        if(rb2d.velocity==Vector2.zero)
        {
            //随机产生数值1/2
            //(1)当随机数为1时，speed为正数
            //(2)当随机数为2是，speed为负数
            rb2d.velocity = new Vector2(((random.Next(0, 2) == 0 ? -1 : 1) * speedX), ((random.Next(0, 2) == 0 ? -1 : 1) * speedY));
        }
    }
    #endregion

    #region 更新得分
    void UpDateScoreText()
    {
        //更新Top、Bottom Text分数
        topText.text = "SCORE:" + scoreEnemy.ToString();       
        bottomText.text = "SCORE:" + scorePlayer.ToString();     
    }
    #endregion

    #region TESING-DEBUG
    void MyDebug(String str, float count)
    {
        Debug.Log(str +count.ToString());
    }
    #endregion
}
