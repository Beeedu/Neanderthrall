using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private PlayerLevel level;

    // Start is called before the first frame update
    void Start()
    {
        this.textMesh = GetComponent<TextMeshProUGUI>();
        this.level = GameManager.instance.GetPlayer().GetComponent<PlayerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textMesh.text = "Level: " + this.level.GetPlayerLevel();
    }
}
