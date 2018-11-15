using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBAnimEvent : MonoBehaviour {
    GBFSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<GBFSMManager>();
    }

    void HitCheck()
    {
        GBATTACK attackState = _manager.CurrentStateComponent as GBATTACK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }
}
