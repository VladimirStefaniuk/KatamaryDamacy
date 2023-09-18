using UnityEngine;

public class GameResultMenu : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private GameObject newGameView;
    [SerializeField] private GameObject pausedView;
    [SerializeField] private GameObject restartGameView;
    [SerializeField] private GameObject looseView;
    [SerializeField] private GameObject wonView;
 
    public void Show(GameState gameState)
    {
        gameObject.SetActive(true);

        Reset();

        switch (gameState)
        {
            case GameState.NewGame:
                newGameView.SetActive(true);
                break;
            case GameState.ActiveGame:
                Hide();
                break;
            case GameState.Paused:
                pausedView.SetActive(true);
                break;
            case GameState.Won:
                wonView.SetActive(true); 
                restartGameView.SetActive(true);
                break;
            case GameState.Lose:
                looseView.SetActive(true); 
                restartGameView.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Reset()
    {
        newGameView.SetActive(false);
        pausedView.SetActive(false);
        wonView.SetActive(false);
        looseView.SetActive(false);
        restartGameView.SetActive(false);
    }
}
