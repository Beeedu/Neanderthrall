using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;

public class AimModeGUI : MonoBehaviour
{
    private TextMeshProUGUI fireModeText;

    // Start is called before the first frame update
    void Start()
    {
        this.fireModeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        AimMode aimMode = GameManager.instance.GetAimMode();

        switch (aimMode)
        {
            case AimMode.Manual:
                this.fireModeText.text = "Q: Toggle Aim Mode (Manual)";
                break;
            case AimMode.Auto:
                this.fireModeText.text = "Q: Toggle Aim Mode (Auto)";
                break;
        }
    }
}
