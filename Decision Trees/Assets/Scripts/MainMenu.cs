using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadScene5()
    {
        SceneManager.LoadScene(5);
    }

    public void ResetLvl()
    {
        DialogueSystemNPC.answeredFirst = false;
        DialogueSystemNPC.answeredFirstYes = false;
        DialogueSystemBox.answeredSecond = false;
        DialogueSystemBox.answeredSecondDestroy = false;
        DialogueSystemBox.answeredSecondTake = false;
        NpcAI.missionEnd = false;
        NpcAI.attackMode = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}