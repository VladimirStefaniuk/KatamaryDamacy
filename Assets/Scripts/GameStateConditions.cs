using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GameStateConditions")]
public class GameStateConditions : ScriptableObject
{
    [Header("Endgame rules")]
    public float RoundDurationSeconds = 180;
    public float KatamariSize = 10; 
}
