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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemySpeedOnCollision = collision.gameObject.GetComponent<CarEnemy>().forwardSpeed;
            playerCurrentHealth += Mathf.Abs(carControl.forwardSpeed) - Mathf.Abs(enemySpeedOnCollision * collision.gameObject.GetComponent<CarEnemy>().damageMultiplier);
        }
    }
}
