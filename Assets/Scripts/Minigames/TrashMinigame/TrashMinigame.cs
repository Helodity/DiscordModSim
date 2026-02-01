using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TrashMinigame : Minigame
{
    [SerializeField] GameObject TrashPrefab;
    [SerializeField] int trashAmt;
    [SerializeField] AudioClip collectionClip;

    [SerializeField] Slider TimerSlider;
    [SerializeField] float timeLimit;

    List<GameObject> TrashSpawnPositions;

    void Start()
    {
        TrashSpawnPositions = GameObject.FindGameObjectsWithTag("TrashSpawnPoint").ToList();
        TimerSlider.maxValue = timeLimit;
        int spawns = 0;
        for(int i = 0; i < trashAmt || TrashSpawnPositions.Count <= 0; i++)
        {
            int idx = Random.Range(0, TrashSpawnPositions.Count);
            GameObject tObj = Instantiate(TrashPrefab, transform);
            tObj.transform.position = TrashSpawnPositions[idx].transform.position;
            TrashSpawnPositions.RemoveAt(idx);
            spawns++;
        }
        trashAmt = spawns; //just in case we spawn too much
    }

    private void Update()
    {
        timeLimit -= Time.deltaTime;
        TimerSlider.value = timeLimit;
        if (timeLimit <= 0)
        {
            EndMinigame(Gamestate.CreateScoreArray(addiction: 0.1f, smelliness: 0.2f));
        }
    }

    public void DropoffTrash()
    {
        trashAmt--;
        AudioSource.PlayClipAtPoint(collectionClip, Vector3.zero);
        if (trashAmt <= 0)
        {
            EndMinigame(Gamestate.CreateScoreArray(smelliness: -0.2f, addiction: -0.05f));
        }
    }
}
