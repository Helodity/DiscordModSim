using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingMinigameManager : Minigame
{
    [SerializeField] TypingList messageLists;

    [SerializeField] TMP_Text toTypeText;
    [SerializeField] TMP_Text typedText;
    [SerializeField] Slider TimerSlider;


    [SerializeField] float[] CompletionScore;
    [SerializeField] float[] FailureScores;
    string targetText;
    int currentPosition;
    [SerializeField] float timePerCharacter;
    float timeRemaining;
    private void Awake()
    {
        targetText = TypingLists.GetRandomTypingPrompt(messageLists);
        toTypeText.text = targetText;
        typedText.text = targetText;
        timeRemaining = timePerCharacter * targetText.Length;
        TimerSlider.maxValue = timeRemaining;
    }


    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                if (c == targetText[currentPosition])
                {
                    do
                    {
                        currentPosition++;
                    }
                    while (currentPosition < targetText.Length - 1 && targetText[currentPosition] == ' '); //Ignore spaces

                    if (currentPosition >= targetText.Length)
                    {
                        EndMinigame(CompletionScore);
                    };
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentPosition--;
        }
        timeRemaining -= Time.deltaTime;
        TimerSlider.value = timeRemaining;
        if (timeRemaining <= 0 || currentPosition < 0)
        {
            EndMinigame(FailureScores);
        }
        typedText.maxVisibleCharacters = currentPosition;

    }

    public void OnExitButtonPress()
    {
        EndMinigame(FailureScores);
    }

}
