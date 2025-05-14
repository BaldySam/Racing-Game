using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private CustomSlider healthBar;
    [SerializeField] private CustomSlider healthBarUI;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Image healthBarFillUI;
    [SerializeField] private Gradient gradient;
    private float enemySpeedOnCollision;
    public float playerMaxHealth = 100;
    public float playerCurrentHealth;
    private CarControl carControl;
    [SerializeField] private PlayerCheckpointSorter playerCheckpointSorter;

    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = PlayerStats.Health.x * 30;
        playerCurrentHealth = playerMaxHealth;
        healthBar.maxValue = playerMaxHealth;
        healthBarUI.maxValue = playerMaxHealth;
        carControl = transform.GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.currentValue = playerCurrentHealth;
        healthBarUI.currentValue = playerCurrentHealth;
        healthBarFill.color = ColorFromGradient(healthBar.currentValue / healthBar.maxValue);
        healthBarFillUI.color = ColorFromGradient(healthBar.currentValue / healthBar.maxValue);
        if(playerCurrentHealth <= 0)
        {
            playerCheckpointSorter.ResetPlayer();
            playerCurrentHealth = playerMaxHealth;
        }
    }

    Color ColorFromGradient (float value)  // float between 0-1
    {
        return gradient.Evaluate(value);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "FrontHitbox")
        {
            CarEnemy carEnemy = collision.transform.parent.GetComponent<CarEnemy>();
            enemySpeedOnCollision = carEnemy.forwardSpeed;
            playerCurrentHealth += Mathf.Abs(carControl.forwardSpeed) - Mathf.Abs(enemySpeedOnCollision * carEnemy.damageMultiplier);
            Debug.Log(Mathf.Abs(carControl.forwardSpeed) - Mathf.Abs(enemySpeedOnCollision * carEnemy.damageMultiplier));
        }
    }
}
