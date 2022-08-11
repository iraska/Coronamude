using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;    //how much damage you can recieve

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");    //this is only going to call those methods that is on the gameObj or its children; when damage taken include player not in chaseRange, enemy is provoked.

        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
