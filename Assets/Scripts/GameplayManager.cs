using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] List<GameObject> MinigamePrefabs;

    [SerializeField] List<string> MinigameDescriptions;

    [SerializeField] List<Ending> Endings;

    [SerializeField] AudioClip MinigameStartClip;

    [Header("Debug")]
    [SerializeField] bool debugMinigame;
    [SerializeField] int debugMinigameIDX;

    int lastRoll = -1;

    [SerializeField] PopupText text;

    GameObject minigameObj;

    // Start is called before the first frame update
    void Start()
    {
        Gamestate.ResetScores();
        StartCoroutine(StartMinigame(2));
    }


    IEnumerator StartMinigame(float delay)
    {
        int index = -1;
        //Prevent Repeats
        do
        {
          index = Random.Range(0, MinigameDescriptions.Count);
        } while (index == lastRoll);
        lastRoll = index;


        if (debugMinigame) index = debugMinigameIDX;

        AudioSource.PlayClipAtPoint(MinigameStartClip, Vector3.zero);
        text.startAnimation(PopupAnimType.TextAppear, delay - 0.5f, MinigameDescriptions[index]);

        yield return new WaitForSeconds(delay);
        text.startAnimation(PopupAnimType.ShrinkOut, 0.5f, MinigameDescriptions[index]);
        minigameObj = Instantiate(MinigamePrefabs[index], transform);
    }


    public void OnMinigameEnd()
    {
        Destroy(minigameObj);
        foreach(Ending e in Endings)
        {
            e.TryForEnding();
        }
        Debug.Log($"Smell:{Gamestate.GetScore(Stats.Smelliness)}, " +
            $"Exposure: {Gamestate.GetScore(Stats.Exposure)}, " +
            $"Heat: {Gamestate.GetScore(Stats.PoliceHeat)}, " +
            $"Mod Skill: {Gamestate.GetScore(Stats.ModSkill)}, " +
            $"Addiction: {Gamestate.GetScore(Stats.Addiction)}");
        StartCoroutine(StartMinigame(2));
    }
}
