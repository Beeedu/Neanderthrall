using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Player player;

    private float clockTimer = 0f;

    public enum AimMode
    {
        Manual,
        Auto,
    }

    private AimMode aimMode = AimMode.Manual;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        this.clockTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (this.aimMode)
            {
                case AimMode.Auto:
                    this.aimMode = AimMode.Manual;
                    break;
                case AimMode.Manual:
                    this.aimMode = AimMode.Auto;
                    break;
            }
        }
    }

    public AimMode GetAimMode()
    {
        return this.aimMode;
    } 

    public float GetClockTime()
    {
        return this.clockTimer;
    }

    public Player GetPlayer()
    {
        return this.player;
    }
}
