using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Ending
{
    public string endingName;
    [SerializeField] CutsceneSO Cutscene;
    [SerializeReference, SubclassSelector] DynamicCondition EndingCondition;
    

    public void TryForEnding()
    {
        if (EndingCondition.Evaluate())
        {
            CutsceneManager.currentCutscene = Cutscene;
            SceneManager.LoadScene("Cutscene");
        }
    }
}
