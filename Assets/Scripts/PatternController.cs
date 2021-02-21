using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public delegate void PublishDieEvent ();
    public static event PublishDieEvent OnDeath;

    void OnEnable()
    {
        TargetController.OnDeath += OnTargetDeath;
    }

    void OnDisable()
    {
        TargetController.OnDeath -= OnTargetDeath;
    }

    void OnTargetDeath() {
        bool noTargetsLeft = GetComponentsInChildren<TargetController>().Length == 1;
        if (noTargetsLeft) {
            PublishDeath();
            TargetController.OnDeath -= OnTargetDeath;
            Destroy(this.gameObject);
        }
    }

    void PublishDeath() {
        Debug.Log(this.gameObject.name);
        if (OnDeath != null) OnDeath();
    }
}
