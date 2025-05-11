using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float playerSpeedOnCollision;
    public float enemyMaxHealth = 20;
    public float enemyCurrentHealth;
    private CarEnemy carEnemy;
    // Start is called before the first frame update
    void Start()
    {
        carEnemy = transform.GetComponent<CarEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            carEnemy.ResetToLastCheckpoint();
            enemyCurrentHealth = enemyMaxHealth;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "PlayerFrontHitbox")
        {
            CarControl carControl = collision.transform.parent.GetComponent<CarControl>();
            playerSpeedOnCollision = carControl.forwardSpeed;
            enemyCurrentHealth += Mathf.Abs(carEnemy.forwardSpeed) - Mathf.Abs(playerSpeedOnCollision * PlayerStats.Damage.x / 10);
        }
    }
}
