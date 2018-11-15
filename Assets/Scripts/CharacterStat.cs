using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField]
    private float _hp = 100.0f;
    public float Hp { get { return _hp; } }

    [SerializeField]
    private float _moveSpeed = 3.0f;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField]
    private float _turnSpeed = 540.0f;
    public float TurnSpeed { get { return _turnSpeed; } }

    [SerializeField]
    private float _attackRange = 2.0f;
    public float AttackRange { get { return _attackRange; } }

    [SerializeField]
    private float _attackPoint = 50.0f;
    public float AttackPoint { set { _attackPoint = value; } get { return _attackPoint; } }

    [SerializeField]
    private float _defensePercent = 0.0f;
    public float DefensePercent { set { _defensePercent = value; } get { return _defensePercent; } }

    public CharacterStat lastHitBy = null;

    public StatData playerStat;

    protected virtual void Awake()
    {
        _hp = playerStat.maxHp;
        _moveSpeed = playerStat.moveSpeed;
        _attackRange = playerStat.baseRange;
        _attackPoint = playerStat.attackPoint;
        _defensePercent = playerStat.defenseP / 100.0f;
    }

    public void TakeDamage(CharacterStat from, float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, playerStat.maxHp);
        if(_hp <= 0)
        {
            if (lastHitBy == null)
                lastHitBy = from;

            GetComponent<IFSMManager>().SetDeadState();
            from.GetComponent<IFSMManager>().NotifyTargetKilled();
            Debug.Log(name + " is Killed by " + lastHitBy.name);
        }
    }

    private static float CalcDamage(CharacterStat from, CharacterStat to)
    {
        return from.AttackPoint * (1 - to.DefensePercent);
    }

    public static void ProcessDamage(CharacterStat from, CharacterStat to)
    {
        float finalDamage = CalcDamage(from, to);
        to.TakeDamage(from, finalDamage);
    }
}
