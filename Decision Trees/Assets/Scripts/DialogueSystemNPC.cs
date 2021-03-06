using UnityEngine;

public class DialogueSystemNPC : MonoBehaviour
{
    [SerializeField] private GameObject FirstPanel;
    [SerializeField] private GameObject ThirdPanel;
    public static bool answeredFirst;
    public static bool answeredFirstYes;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player" && !answeredFirst)
            FirstPanel.SetActive(true);

        if (collider.tag == "Player" && DialogueSystemBox.answeredSecond && !NpcAI.missionEnd)
        {
            ThirdPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
            FirstPanel.SetActive(false);
    }
}