using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public delegate void PublishDieEvent (PatternController pattern);
    public static event PublishDieEvent OnDeath;
    private int numTargets = 0;

    public void makeActivePattern()
    {
        numTargets = GetComponentsInChildren<TargetController>().Length;
        TargetController.OnDeath += OnTargetDeath;
    }

    void OnDestroy() {
        TargetController.OnDeath -= OnTargetDeath;
    }

    void OnTargetDeath() {
        numTargets -= 1;
        bool noTargetsLeft = numTargets == 0;
        if (noTargetsLeft) {
            PublishDeath();
            TargetController.OnDeath -= OnTargetDeath;
        }
    }

    void PublishDeath() {
        Debug.Log(this.gameObject.name);
        if (OnDeath != null) OnDeath(this);
    }
}
