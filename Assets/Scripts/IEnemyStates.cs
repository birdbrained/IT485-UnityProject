using UnityEngine;
using System.Collections;

public interface IEnemyStates
{
    void Execute();
    void Enter(Enemy enemy);
    void Exit();
    void OnTriggerEnter(Collider other);

}
