using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; private set; }

    public UnityEvent<float> OnCoreHealthChanged;
    public UnityEvent OnCoreDestroyed;
    public UnityEvent OnEnemyKilled;
    public UnityEvent OnGameWon;

    private int enemiesKilled = 0;
    [SerializeField] private int enemiesToWin = 10;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ReportCoreHealthChanged(float percent)
    {
        OnCoreHealthChanged?.Invoke(percent);
    }

    public void ReportCoreDestroyed()
    {
        OnCoreDestroyed?.Invoke();
    }

    public void ReportEnemyKilled()
    {
        enemiesKilled++;
        OnEnemyKilled?.Invoke();

        if (enemiesKilled >= enemiesToWin)
            OnGameWon?.Invoke();
    }
}