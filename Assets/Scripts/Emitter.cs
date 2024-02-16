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
        ActionTimer.Create(EmitProjectile, 1f);
    }

    public void EmitProjectile()
    {
        GameObject player = this.transform.parent.gameObject;
        Transform projectileTransform = Instantiate(this.pfProjectile, this.transform.position, Quaternion.identity);

        Vector3 aimDirection;
        AimMode aimMode = GameManager.instance.GetAimMode();
        switch (aimMode)
        {
            case AimMode.Manual:
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                aimDirection = (new Vector3(mousePosition.x, mousePosition.y) - player.transform.position).normalized;
                break;
            case AimMode.Auto:
                // TODO: Implement Auto Aim
                aimDirection = new Vector3(0, 0, 0);
                break;
            default:
                aimDirection = new Vector3(0, 0, 0);
                break;
        }

        projectileTransform.GetComponent<Projectile>().Setup(aimDirection);

        SoundManager.instance.PlayThrowSound();
    }
}
