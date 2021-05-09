using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystemBox : MonoBehaviour
{
    [SerializeField] private GameObject SecondPanel;
    public static bool answeredSecond;
    public static bool answeredSecondDestroy;
    public static bool answeredSecondTake;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !answeredSecond && DialogSystemNPC.answeredFirstYes)
            SecondPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
            SecondPanel.SetActive(false);
    }
}
