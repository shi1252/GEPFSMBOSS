using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GBFSMManager))]
public class GBFSMState : MonoBehaviour {
    protected GBFSMManager _manager;

    static bool phase1;
    static bool phase2;

    private void Awake()
    {
        phase1 = false;
        phase2 = false;
        _manager = GetComponent<GBFSMManager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
    protected virtual void Update()
    {
        if (GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            if (_manager.PlayerTransform == null)
            {
                _manager.SetState(GBState.IDLE);
            }
        }

        if (!phase1 && _manager.Stat.Hp < _manager.Stat.playerStat.maxHp * _manager.Stat.Phase1HpPercent)
        {
            phase1 = !phase1;
            Instantiate(_manager.Stat.matpi, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
            Instantiate(_manager.Stat.matpi, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        }

        if (!phase2 && _manager.Stat.Hp < _manager.Stat.playerStat.maxHp * _manager.Stat.Phase2HpPercent)
        {
            phase2 = !phase2;
            _manager.Stat.ps.SetActive(true);
            _manager.Stat.AttackPoint = _manager.Stat.AttackPoint * 1.5f;
            _manager.Stat.DefensePercent = _manager.Stat.DefensePercent * 1.5f;
        }
    }
}
