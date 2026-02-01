using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPlayerSprite : MonoBehaviour
{
    [SerializeField] Sprite FullSmell;
    [SerializeField] Sprite HalfSmell;
    [SerializeField] Sprite NoSmell;

    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        float smell = Gamestate.GetScore(Stats.Smelliness);

        if(smell > 0.7f)
        {
            img.sprite = FullSmell;
            return;
        }
        if(smell > 0.4f)
        {
            img.sprite = HalfSmell;
            return;
        }
        img.sprite = NoSmell;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
