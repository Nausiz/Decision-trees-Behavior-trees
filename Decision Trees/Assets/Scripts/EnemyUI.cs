using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Text HPThreshold;
    [SerializeField] private Text HPRegen;
    [SerializeField] private Text ChaseRange;
    [SerializeField] private Text AtackRange;

    [SerializeField] private Slider HPThresholdSlider;
    [SerializeField] private Slider HPRegenSlider;
    [SerializeField] private Slider ChaseRangeSlider;
    [SerializeField] private Slider AtackRangeSlider;

    void Update()
    {
        if (CameraController.blocked)
        {
            HPThreshold.text = "Limit HP do ucieczki: " + HPThresholdSlider.value.ToString("0");
            HPRegen.text = "Regeneracja HP: " +  HPRegenSlider.value.ToString("0");
            ChaseRange.text = "Zasieg gonienia: " + ChaseRangeSlider.value.ToString("0");
            AtackRange.text = "Zasieg ataku: " + AtackRangeSlider.value.ToString("0");
        }
    }
}
