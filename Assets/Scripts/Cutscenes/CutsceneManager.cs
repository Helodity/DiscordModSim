using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneSO currentCutscene;

    [SerializeField] Transform characterParent;
    [SerializeField] Image characterPrefab;
    public int dialogueIdx;
    public Image backgroundRenderer;

    List<Image> characterObjects = new List<Image>();

    public TMP_Text Textbox;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeCutscene();
    }


    void InitializeCutscene()
    {
        backgroundRenderer.sprite = currentCutscene.BackgroundSprite;
        float canvasWidth = ((Canvas)FindAnyObjectByType(typeof(Canvas))).GetComponent<RectTransform>().rect.width;
        for (int i = 0; i < currentCutscene.characters.Count; i++)
        {
            float ratio = (float)(i + 1) / (currentCutscene.characters.Count + 1) * 2 - 1;

            CutsceneCharacter c = currentCutscene.characters[i];
            Image newChar = Instantiate(characterPrefab, characterParent);
            characterObjects.Add(newChar);
            newChar.sprite = c.characterSprite;
            //newChar.rectTransform.re = c.characterSprite.textureRect.height;


            newChar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentCutscene.characters[i].size.x);
            newChar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentCutscene.characters[i].size.y);
            if (currentCutscene.characters[i].spawnPos != Vector2.zero)
            {
                newChar.rectTransform.anchoredPosition = currentCutscene.characters[i].spawnPos;
                continue;
            }
            newChar.rectTransform.anchoredPosition = new Vector3(ratio * (canvasWidth * 0.5f), 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueIdx >= currentCutscene.dialogue.Count)
        {
            SceneManager.LoadScene(currentCutscene.sceneOnFinish);
            return;
        }
        Textbox.text = currentCutscene.dialogue[dialogueIdx].Text;

        for (int i = 0; i < currentCutscene.characters.Count; i++)
        {
            if (currentCutscene.dialogue[dialogueIdx].SpeakerIdx == i)
            {
                characterObjects[i].color = new Color(1, 1, 1);
            }
            else
            {
                characterObjects[i].color = new Color(0.8f, 0.8f, 0.8f);
            }
        }

        if (Input.anyKeyDown)
        {
            dialogueIdx += 1;
        }
    }
}
