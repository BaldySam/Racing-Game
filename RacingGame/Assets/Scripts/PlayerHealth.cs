using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private CustomSlider healthBar;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Gradient gradient;
    private float enemySpeedOnCollision;
    public float playerMaxHealth = 100;
    public float playerCurrentHealth;
    private CarControl carControl;
    public bool hit;
    Collider collisionToSet;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = playerMaxHealth;
        carControl = transform.GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.currentValue = playerCurrentHealth;
        healthBarFill.color = ColorFromGradient(healthBar.currentValue / healthBar.maxValue);
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
