using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameplayCore : MonoBehaviour
{
    [Header("Endgame rules")]
    [SerializeField] private GameStateConditions endGameConditions;

    private float _playerSize;

    // variables for tracking time left
    private float _timeLeft;
    public float TimeLeft
    {
        get => _timeLeft;
        set {
            _timeLeft = value;
            OnGameplayTimeTick.Invoke(_timeLeft);
        }
    }
    public UnityEvent<float> OnGameplayTimeTick;

    // game state
    private GameState _gameState;
    public GameState GameState
    {
        get => _gameState;
        set
        {
            _gameState = value;
            OnGameStateChanged.Invoke(GameState);
        }
    } 
    public UnityEvent<GameState> OnGameStateChanged;


    public void Start()
    {
        GameState = GameState.NewGame;
    }
 
    public void OnPlayerSizeChanged(float size)
    {
        _playerSize = size;
        CheckGameResult();
    }

    private void Update()
    {
        if (GameState != GameState.ActiveGame)
            return;

        TimeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
        {
            // time ended - stop game 
            CheckGameResult();
        } 
    }

    public void PauseGame()
    {
        if (GameState == GameState.ActiveGame)
        {
            GameState = GameState.Paused;
            Time.timeScale = 0.0f;
        }
    }

    public void UnpauseGame()
    {
        GameState = GameState.ActiveGame;
        Time.timeScale = 1.0f;
    }
 
    public void StartNewGame()
    {
        _playerSize = 0;
        TimeLeft = endGameConditions.RoundDurationSeconds;
        GameState = GameState.ActiveGame;
    }

    public void RestartGame()
    {
        // reload current scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void CheckGameResult()
    {
        if (GameState != GameState.ActiveGame)
            return;

        // WON - if player size >= target size
        if (_playerSize >= endGameConditions.KatamariSize)
        {
            GameState = GameState.Won;
            return;
        }

        // LOSE - if out of time
        if (TimeLeft <= 0)
        {
            GameState = GameState.Lose;
            return;
        }
    }
}
