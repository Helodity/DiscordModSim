using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] CutsceneSO IntroCutscene;
    public void StartGame()
    {
        Gamestate.ResetScores();
        CutsceneManager.currentCutscene = IntroCutscene;
        SceneManager.LoadScene("Cutscene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Start()
    {
        
    }
}
