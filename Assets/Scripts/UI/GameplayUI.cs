using System;
using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] TMP_Text playerSizeText;
    [SerializeField] TMP_Text timeLeftText;
     
    [SerializeField] GameResultMenu gameResultMenu;

    #region "Events"
    public void OnPlayerSizeChanged(float size)
    {
        playerSizeText.text = size.ToString("0.00");
    }

    public void OnGameplayTimeChanged(float timeLeft)
    {
        // Format the time into minutes and seconds.
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timeLeftText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnGameStateChanged(GameState gameState)
    {
        gameResultMenu.Show(gameState);
    }

    #endregion

    public void OnPauseButtonClick()
    { 
        // pause game
        Time.timeScale = 0.0f;

        // show menu 
        gameResultMenu.Show(GameState.ActiveGame);
    }

    public void OnContinueButtonClick()
    {
        // pause game
        Time.timeScale = 1.0f;

        gameResultMenu.Hide();
    }
}
