using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected void EndMinigame(float[] scoreChanges)
    {
        GameplayManager manager = (GameplayManager)FindFirstObjectByType(typeof(GameplayManager));
        if (manager)
        {
            Gamestate.AddScore(scoreChanges);
            manager.OnMinigameEnd();
        }
    }
}
