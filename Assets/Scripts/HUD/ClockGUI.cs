using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockGUI : MonoBehaviour
{

    private TextMeshProUGUI clockText;

    // Start is called before the first frame update
    void Start()
    {
        this.clockText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        this.clockText.text = "" + FormatClockTime(GameManager.instance.GetClockTime());
    }

    private string FormatClockTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return $"{FormatLeadingZero(minutes)}:{FormatLeadingZero(seconds)}";
    }

    private string FormatLeadingZero(int time)
    {
        return (time < 10 ? "0" + time : "" + time);
    }
}
