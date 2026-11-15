using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null )
        {
            takeDamage(damageDealer.GetDamage());
            playHitParticles();
            damageDealer.Hit();
            audioManager.PlayDamageSFX();

            if (applyCameraShake)
            {
                cameraShake.Play();
            }
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreValue);
        }
        Destroy(gameObject);
    }

    void playHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
}
