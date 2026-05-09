using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip enemyDeathSound;
    [SerializeField] private AudioClip coreHitSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

        void Start()
    {
        Debug.Log("AudioManager Instance: " + Instance);
        Debug.Log("Shoot Sound: " + shootSound);
    }

    public void PlayShoot()
{
    Debug.Log("PlayShoot called");
    audioSource.PlayOneShot(shootSound);
}
    public void PlayEnemyDeath() => audioSource.PlayOneShot(enemyDeathSound);
    public void PlayCoreHit() => audioSource.PlayOneShot(coreHitSound);
    public void PlayWin() => audioSource.PlayOneShot(winSound);
    public void PlayLose() => audioSource.PlayOneShot(loseSound);
}