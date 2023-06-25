using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
   public float enemyHealth = 100f;
    public void DeductHealth(float deductHealth){
        enemyHealth -= deductHealth;
        if(enemyHealth <= 0){
            EnemyDead();
        }

        void EnemyDead(){
            Destroy(gameObject);
        }
    }




}
