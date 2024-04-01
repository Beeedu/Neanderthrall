using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManGUI : MonoBehaviour
{

    private TextMeshProUGUI textMesh;

    private PlayerAbility ability; 

    // Start is called before the first frame update
    void Start()
    {
        this.textMesh = GetComponent<TextMeshProUGUI>();
        this.ability = GameManager.instance.GetPlayer().GetComponent<PlayerAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textMesh.text = "Mana: " + FormatMana(this.ability.GetMana(), this.ability.GetMaxMana());
    }

    private string FormatMana(float mana, float maxMana)
    {
        int manaRounded = Mathf.RoundToInt(mana);
        int maxManaRounded = Mathf.RoundToInt(maxMana);

        return $"{manaRounded} / {maxManaRounded}";
    }
}
