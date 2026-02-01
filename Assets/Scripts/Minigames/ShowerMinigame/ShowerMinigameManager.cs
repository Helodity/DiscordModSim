using UnityEngine;
using UnityEngine.UI;

public class ShowerMinigameManager : Minigame
{

    [SerializeField] GameObject dropletPrefab;
    [SerializeField] Vector2 xBounds;
    [SerializeField] AudioClip collectionClip;

    [SerializeField] float scoreNeeded = 10;
    [SerializeField] float timeRemaining = 10;

    [SerializeField] float minSpawnDelay = 0.6f;
    [SerializeField] float maxSpawnDelay = 0.9f;
    float spawnTimeRemaining = 0;

    [Header("UI")]
    [SerializeField] Slider TimeSlider;
    [SerializeField] Slider ScoreSlider;


    private void Awake()
    {
        TimeSlider.maxValue = timeRemaining;
        ScoreSlider.maxValue = scoreNeeded;
    }

    public void CollectWater()
    {
        scoreNeeded--;
        AudioSource.PlayClipAtPoint(collectionClip, Vector3.zero);
        if(scoreNeeded <= 0)
        {
            EndMinigame(Gamestate.CreateScoreArray(smelliness: -0.2f));
        }
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            EndMinigame(Gamestate.CreateScoreArray(smelliness: 0.2f));
            return;
        }

        spawnTimeRemaining -= Time.deltaTime;
        if(spawnTimeRemaining <= 0)
        {
            GameObject obj = Instantiate(dropletPrefab, transform);
            obj.transform.localPosition = Vector3.right * Random.Range(xBounds.x, xBounds.y);
            Destroy(obj, 10);
            spawnTimeRemaining += Random.Range(minSpawnDelay, maxSpawnDelay);
        }
        TimeSlider.value = timeRemaining;
        ScoreSlider.value = ScoreSlider.maxValue - scoreNeeded;
    }
}
