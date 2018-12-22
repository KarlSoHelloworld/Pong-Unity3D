using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    //游戏进程管理
    public GameObject gameManager;
    void Awake()
    {
        //当GameManager不存在时，初始化之
        if (GameManager.gameManagerInstance == null)
        {
            Instantiate(gameManager);
        }
    }
}
