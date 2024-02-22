using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField]
    private Transform prefabProjectile;

    [SerializeField]
    private float maxMana;

    private float mana = 0f;
    private float manaGain = 10f;

    private void Start()
    {
        EventManager.instance.AttackFirstHit += GainMana;
    }

    private void Update()
    {
        if (mana >= maxMana)
        {
            CastAbility();
        }
    }

    private void CastAbility()
    {
        this.mana -= this.maxMana;

        Transform projectileTransform = Instantiate(prefabProjectile, this.transform.position, Quaternion.identity);

        Vector3 aimDirection = GameManager.instance.GetPlayerAim().DetermineAimDirection(GameManager.instance.GetAimMode());

        projectileTransform.GetComponent<Projectile>().Setup(aimDirection);
    }

    private void GainMana()
    {
        this.mana += this.manaGain;
    }
}
