using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Player player;
    public Slider expSlider;

    private float easeSpeed = 0.05f;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        expSlider.maxValue = player.lvlUpExpRequired;
        expSlider.minValue = 0;
        expSlider.value = 0;
    }

    void Update()
    {
        expSlider.value = Mathf.Lerp(expSlider.value, player.exp, easeSpeed);
    }
}
