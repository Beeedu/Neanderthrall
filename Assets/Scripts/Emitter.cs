using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Emitter : MonoBehaviour
{
    [SerializeField]
    Transform pfProjectile;

    // Start is called before the first frame update
    void Start()
    {
        //ActionTimer.Create(() => Emit(this.pfProjectile), 1f);
    }

    public void Emit(Transform prefab)
    {
        Transform projectileTransform = Instantiate(prefab, this.transform.position, Quaternion.identity);

        Vector3 aimDirection = GameManager.instance.GetPlayerAim().DetermineAimDirection(GameManager.instance.GetAimMode());

        projectileTransform.GetComponent<Projectile>().Setup(aimDirection);

        SoundManager.instance.PlayThrowSound();
    }

}
