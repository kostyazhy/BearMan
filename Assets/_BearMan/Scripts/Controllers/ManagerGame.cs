using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class ManagerGame : MonoBehaviour
{
    // use STimer & MovementPlayer & UiControlGame & ObstacleControl & Obstacle & PlayClipBG
    public delegate void ChangeStateGame(int eventGame);
    public static event ChangeStateGame OnChangeStateGame;

    public GameObject player;

    private int stateGame;
    

  /*  private void OnEnable()
    {
        STimer.OnStopTimer += ProcessingEventGame;
        UiControlGame.OnUIEvent += ProcessingEventGame;
        HealthPlayer.OnEvetOfPlayer += ProcessingEventGame;
        FinishPoint.OnFinishPoint += ProcessingEventGame;
    }

    private void OnDisable()
    {
        STimer.OnStopTimer -= ProcessingEventGame;
        UiControlGame.OnUIEvent -= ProcessingEventGame;
        HealthPlayer.OnEvetOfPlayer -= ProcessingEventGame;
        FinishPoint.OnFinishPoint -= ProcessingEventGame;
    }*/

    private void Start()
    {
        StartCoroutine(RestartGame());
    }

    private void StartGame()
    {
        //player.SetActive(true);
        //player.GetComponent<FirstPersonController>().enabled = true;
        if (OnChangeStateGame != null) {
            OnChangeStateGame(StateGame.START_GAME);
        }
        stateGame = StateGame.START_GAME;
    }

    private void FinishGame()
    {
        if (OnChangeStateGame != null) {
            OnChangeStateGame(StateGame.FINISH_GAME);
        }
        stateGame = StateGame.FINISH_GAME;
    }

    private IEnumerator RestartGame()
    {
        if (OnChangeStateGame != null) {
            OnChangeStateGame(StateGame.RESTART_GAME);
        }
        yield return new WaitForSeconds(1);
        StartGame();
    }

    private void StopGame()
    {
        //player.GetComponent<FirstPersonController>().enabled = false;
        
        if (OnChangeStateGame != null) {
            OnChangeStateGame(StateGame.STOP_GAME);
        }
        stateGame = StateGame.STOP_GAME;
    }

    private void GameOver()
    {
        StopGame();
        if (OnChangeStateGame != null) {
            OnChangeStateGame(StateGame.GAME_OVER);
        }
        stateGame = StateGame.GAME_OVER;
    }

    private void ProcessingEventGame(int eventGame)
    {
        switch (stateGame) {
            case StateGame.START_GAME: {
                    if (eventGame == StateGame.STOP_GAME) {
                        StopGame();
                    } else if(eventGame == StateGame.FINISH_GAME) {
                        FinishGame();
                    } else if(eventGame == StateGame.GAME_OVER) {
                        GameOver();
                    }
                }
                break;
            case StateGame.STOP_GAME: {
                    if(eventGame == StateGame.START_GAME) {
                        StartGame();
                    } else if(eventGame == StateGame.RESTART_GAME) {
                        StartCoroutine(RestartGame());
                    }
                }
                break;
            case StateGame.FINISH_GAME: {
                    if (eventGame == StateGame.RESTART_GAME) {
                        StartCoroutine(RestartGame());
                    }
                }
                break;
            case StateGame.GAME_OVER: {
                    if (eventGame == StateGame.RESTART_GAME) {
                        StartCoroutine(RestartGame());
                    }
                }
                break;
        }
    }
}

public static class StateGame
{
    public const int START_GAME = 0;
    public const int STOP_GAME = 1;
    public const int FINISH_GAME = 3;
    public const int RESTART_GAME = 4;
    public const int GAME_OVER = 5;
}
