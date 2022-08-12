using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;    //how much damage you can recieve

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");    //this is only going to call those methods that is on the gameObj or its children; when damage taken include player not in chaseRange, enemy is provoked.

        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die() //for bug: when zombie after die, he can die again
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die"); //it can't kill the player bug: add an atack animation event (AttackHitEvent)
    }
}
