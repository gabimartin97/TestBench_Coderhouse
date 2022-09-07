using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialEnemy : EnemyBehaviour
{
   public override void RecieveDamage(float damage)
    {
        health -= damage;
        Warp();
    }
    private void Warp()
    {
        Vector3 newPosition = new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));
        gameObject.GetComponent<NavMeshAgent>().Warp(newPosition);
    }
}
