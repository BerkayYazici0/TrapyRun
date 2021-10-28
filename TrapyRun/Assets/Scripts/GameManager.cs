using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameStatus gameStatus;
    [Header("Level")]
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private int currentLevelIndex;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlaneMech planeMech;
    [SerializeField] private GameObject player;
    private void Start()
    {
        gameStatus = GameStatus.MENU;
        currentLevelIndex = 0;
        Time.timeScale = 0f;
    }

    private void LevelLoad()
    {
        if (currentLevel)
        {
            DestroyImmediate(currentLevel);
        }

        if(currentLevelIndex >= levels.Length)
        {
            currentLevelIndex = 0;
        }

        currentLevel = Instantiate(levels[currentLevelIndex]);
    }

   public void Fail()
    {
        UIManager.Instance.Fail();
        gameStatus = GameStatus.FAIL;
    }

    public void Success()
    {
        UIManager.Instance.Success();
        gameStatus = GameStatus.SUCCESS;
    }

    public void NextLevel()
    {
        gameStatus = GameStatus.PLAY;
        playerMovement.speed = 3f;
        playerMovement.leftRightSpeed = 5f;
        planeMech.playerAnim.SetBool("isLevelFinish", false);
        player.transform.position = new Vector3(0f, 1f, 0f);
        currentLevelIndex++;
        LevelLoad();
    }

    public void RestartLevel()
    {
        gameStatus = GameStatus.PLAY;
        SceneManager.LoadScene("Game");        
    }

    public void StartGame()
    {
        gameStatus = GameStatus.PLAY;
        Time.timeScale = 1f;
        LevelLoad();
    }

    public enum GameStatus
    {
        MENU,
        PLAY,
        FAIL,
        SUCCESS
    }
}
