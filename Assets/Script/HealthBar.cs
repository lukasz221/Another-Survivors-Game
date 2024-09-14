using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;
    public Slider healthSlider;

    private float easeSpeed = 0.05f;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        healthSlider.minValue = 0;
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.currentHealth;
    }

    void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, player.currentHealth, easeSpeed);
    }

}