using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer _instance;

    [Header("Shooting")] [SerializeField] private AudioClip shootingClip;

    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 0.5f;

    [Header("Damage")] [SerializeField] private AudioClip damageClip;

    [SerializeField] [Range(0f, 1f)] private float damageVolume = 0.5f;

    public void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}