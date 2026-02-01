using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinnerMinigameManager : Minigame
{
    [SerializeField] GameObject dadBubble;
    [SerializeField] GameObject momBubble;
    [SerializeField] GameObject loseBubble;
    [SerializeField] GameObject winBubble;
    [SerializeField] GameObject thoughtBubble;
    [SerializeField] Slider TimerSlider;
    [SerializeField] AudioClip ClickClip;

    [SerializeField] float cycleDur;
    float timeElapsed = 0.0f;
    [SerializeField] float clickTimer = 5;
    [SerializeField] float clickAddAmt = 0.15f;
    [SerializeField] float minAppearTime = 5;
    [SerializeField] float maxAppearTime = 7;
    void Start()
    {
        dadBubble.SetActive(false);
        momBubble.SetActive(false);
        loseBubble.SetActive(false);
        thoughtBubble.SetActive(false);
        winBubble.SetActive(false);
        float time = Random.Range(minAppearTime, maxAppearTime);
        StartCoroutine(doLoseBubble(time));
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int cycle = (int)Mathf.Floor(timeElapsed * (1 / cycleDur));

        momBubble.SetActive(cycle % 2 == 0 && !loseBubble.activeSelf);
        dadBubble.SetActive(cycle % 2 == 1 && !loseBubble.activeSelf);
    }

    IEnumerator doLoseBubble(float delay)
    {
        yield return new WaitForSeconds(delay);
        TimerSlider.maxValue = clickTimer;
        clickTimer *= 0.75f;
        thoughtBubble.SetActive(true);

        while(clickTimer > 0)
        {
            clickTimer -= Time.deltaTime;
            TimerSlider.value = clickTimer;

            if (Input.anyKeyDown)
            {
                AudioSource.PlayClipAtPoint(ClickClip, Vector3.zero);
                clickTimer += clickAddAmt;
                if(clickTimer > TimerSlider.maxValue)
                {
                    thoughtBubble.SetActive(false);
                    winBubble.SetActive(true);
                    yield return new WaitForSeconds(2);
                    EndMinigame(Gamestate.CreateScoreArray(exposure: -0.05f, addiction: -0.05f));
                    yield break; //Exit
                }
            }

            yield return null;
        }
        loseBubble.SetActive(true);
        thoughtBubble.SetActive(false);
        yield return new WaitForSeconds(3);
        EndMinigame(Gamestate.CreateScoreArray(exposure: 0.2f, policeHeat: 0.1f, addiction: 0.05f));

    }
}
