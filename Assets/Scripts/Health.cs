using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int scoreValue = 50;

    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool applyCameraShake;

    private AudioPlayer _audioPlayer;
    private CameraShake _cameraShake;
    private LevelManager _levelManager;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageDealer = col.gameObject.GetComponent<DamageDealer>();

        if (damageDealer == null) return;
        TakeDamage(damageDealer.GetDamage());
        PlayHitEffect();
        _audioPlayer.PlayDamageClip();
        ShakeCamera();
        damageDealer.Hit();
    }

    private void ShakeCamera()
    {
        if (_cameraShake != null && applyCameraShake)
        {
            _cameraShake.Play();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            _scoreKeeper.ModifyScore(scoreValue);
        }
        else
        {
            _levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }

    private void PlayHitEffect()
    {
        if (hitEffect == null) return;
        var instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

    public int GetHealth() => health;
}