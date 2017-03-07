using UnityEngine;
using System.Collections;

public class AttackState : IEnemyStates 
{
    private Enemy enemy;
    private float fireTimer;
    private float fireCooldown = 3;
    private bool canFire = true;
    private float attackTimer;
    private float attackCooldown = 3;
    private bool canAttack = true;

    public void Enter(Enemy e)
    {
        enemy = e;
        Debug.Log("Attack");
    }

    public void Execute()
    {
        if (enemy.hasARangedAttack)
        {
            Fire();
            if (enemy.Target != null)
            {
                //enemy.Move();
            }
            else
            {
                enemy.ChangeState(new IdleState());
            }
        }
        if (enemy.hasAMeleeAttack)
        {
            Attack();
            if (enemy.Target == null)
            {
                enemy.ChangeState(new IdleState());
            }
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    private void Fire()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireCooldown)
        {
            canFire = true;
            fireTimer = 0;
        }
        if (canFire)
        {
            canFire = false;
            enemy.MyAnimator.SetTrigger("fire");
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("attack");
        }
    }
}
