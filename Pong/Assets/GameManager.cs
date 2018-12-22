using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("游戏载入延迟")]
    public float levelStartDelay = 2f;

    [Header("游戏进程")]
    public static GameManager gameManagerInstance = null;

    /* 未来拓展游戏难度用
    private Text levelText;
    private GameObject levelImage;
    static int level = 1;

    */

    [Header("游戏开始按钮")]
    public Button startButton;

    [Header("欢迎页面Object")]
    private static GameObject welcomePage;


    // Use this for initialization
    private void Awake()
    {
        if (gameManagerInstance == null)
            gameManagerInstance = this;
        else if (gameManagerInstance != this)
            Destroy(gameManagerInstance);

        welcomePage = GameObject.FindGameObjectWithTag("WelcomePage");

        ShowWelcomePage();

        startButton.onClick.AddListener(StartButtonClick);

        
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]

    #region welcomepage的显示与隐藏
    private void ShowWelcomePage()
    {
        welcomePage.SetActive(true);        
    }

    private void HideWelcomePage()
    {        
        welcomePage.SetActive(false);      
    }
    #endregion

    #region 游戏停止
    private void StopGame()
    {
        GameObject.FindGameObjectWithTag("Ball").SetActive(false);
        GameObject.FindGameObjectWithTag("Background").SetActive(false);
    }
    #endregion

    #region 游戏开始按钮点击事件
    private void StartButtonClick()
    {
        StartCoroutine(StartGame());
    }
    #endregion

    #region 游戏初始化，调用主游戏场景Game
    IEnumerator StartGame()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("Game");

        yield return new WaitForEndOfFrame();

        op.allowSceneActivation = true;
    }
    #endregion

    /*未来拓展用
    public static void LevelUp()
    {
        level++;
    }

    public static void LevelReset()
    {
        level = 1;
    }
    */



}
