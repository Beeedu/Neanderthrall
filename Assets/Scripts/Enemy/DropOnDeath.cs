using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    [SerializeField]
    GameObject drop;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        this.isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!this.isQuitting)
        {
            Instantiate(drop, this.transform.position, Quaternion.identity);
        }
    }
}
