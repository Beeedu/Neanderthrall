using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer
{

    private float interval;
    private float timer = 0f;
    private Action action;

    public ActionTimer(Action action, float interval)
    {
        this.action = action;
        this.interval = interval;
    }

    public void Update()
    {
        this.timer += Time.deltaTime;
        if (timer >= interval)
        {
            this.action();
            timer = 0f;
        }
    }

    public static ActionTimer Create(Action action, float interval)
    {
        ActionTimer actionTimer = new ActionTimer(action, interval);

        GameObject gameObject = new GameObject("ActionTimer", typeof(MonoBehaviorHook));
        gameObject.GetComponent<MonoBehaviorHook>().onUpdate = actionTimer.Update;

        return actionTimer;
    }

    public class MonoBehaviorHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null)
            {
                onUpdate();
            }
        }
    }
}
