using UnityEngine; 
using TMPro;

public class NewGameView : MonoBehaviour
{
	[SerializeField] TMP_Text gameConditionsText;
    [Header("Endgame rules")]
    [SerializeField] private GameStateConditions endGameConditions;

    // Use this for initialization
    private void Start()
	{
        PopulateTutorialText();
    }

    private void PopulateTutorialText()
    {
        try
        {
            gameConditionsText.text = string.Format(gameConditionsText.text, endGameConditions.KatamariSize, endGameConditions.RoundDurationSeconds);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Can't create new game tutorial label");
            Debug.LogException(ex);
        }
    }
}

