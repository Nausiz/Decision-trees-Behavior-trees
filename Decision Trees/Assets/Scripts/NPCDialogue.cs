using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private GameObject FirstPanel;
    [SerializeField] private GameObject SecondPanel;
    [SerializeField] private GameObject ThirdPanel;
    [SerializeField] private Text text;
    [SerializeField] private GameObject Box;

    private void Update()
    {
        if (FirstPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                DialogueSystemNPC.answeredFirst = true;
                DialogueSystemNPC.answeredFirstYes = true;
                FirstPanel.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                DialogueSystemNPC.answeredFirst = true;
                DialogueSystemNPC.answeredFirstYes = false;
                FirstPanel.SetActive(false);
            }
        }

        if (SecondPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DialogueSystemBox.answeredSecond = true;
                DialogueSystemBox.answeredSecondDestroy = true;
                DialogueSystemBox.answeredSecondTake = false;
                NpcAI.attackMode = true;
                text.text = "Dlaczego zniszczy³eœ moje drogocenne pude³ko?! Zap³acisz za to!";
                Destroy(Box);
                SecondPanel.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueSystemBox.answeredSecond = true;
                DialogueSystemBox.answeredSecondDestroy = false;
                DialogueSystemBox.answeredSecondTake = true;
                text.text = "Dziêkujê za pomoc! Teraz ja Ci siê chêtnie jakoœ odp³acê";
                Destroy(Box);
                SecondPanel.SetActive(false);
            }
        }

        if (ThirdPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                NpcAI.missionEnd = true;
                ThirdPanel.SetActive(false);
            }
        }
    }
}
