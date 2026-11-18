using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [SerializeField] TextMeshProUGUI HealthText;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeeper;

    void Start()
    {
        scorekeeper = FindAnyObjectByType<ScoreKeeper>();
        healthSlider.maxValue = playerHealth.GetHealth();
        HealthText.text = playerHealth.GetHealth().ToString();
    }

    void Update()
    {
        scoreText.text = scorekeeper.GetScore().ToString("000000000");
        healthSlider.value = playerHealth.GetHealth();
        HealthText.text = playerHealth.GetHealth().ToString();
    }
}
