using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    float animDur;
    float animDurRemaining;
    PopupAnimType animType;

    [SerializeField] TMP_Text textbox;
    void Awake()
    {
        animDurRemaining = 0f;
        textbox = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (animDurRemaining > 0f)
        {
            animDurRemaining -= Time.deltaTime;
        } else
        {
            animDurRemaining = 0f;
        }

        switch (animType)
        {
            case PopupAnimType.TextAppear:
                transform.localScale = Vector3.one * easeOutElastic(1 - (animDurRemaining / animDur));
                break;
            case PopupAnimType.ShrinkOut:
                transform.localScale = Vector3.one * (1 - easeInSine(1 - (animDurRemaining / animDur)));
                break;
        }
    }

    float easeOutElastic(float x) {
        const float c4 = (2 * Mathf.PI) / 3;

        return x == 0 ? 0
        : x == 1
        ? 1
        : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    float easeInSine(float x) {
        return 1 - Mathf.Cos((x * Mathf.PI) / 2);
    }

    public void hideAnimation()
    {
        textbox.text = string.Empty;
    }

    public void startAnimation(PopupAnimType type, float duration, string text)
    {
        animDur = duration;
        animDurRemaining = duration;
        textbox.text = text;
        animType = type;
    }
}

public enum PopupAnimType
{
    TextAppear,
    ShrinkOut
}