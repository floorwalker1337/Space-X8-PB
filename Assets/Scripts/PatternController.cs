using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public delegate void PublishPatternDieEvent (PatternController pattern);
    public event PublishPatternDieEvent OnPatternDeath;
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
            TargetController.OnDeath -= OnTargetDeath;
            PublishDeath();
        }
    }

    void PublishDeath() {
        if (OnPatternDeath != null) OnPatternDeath(this);
    }
}
