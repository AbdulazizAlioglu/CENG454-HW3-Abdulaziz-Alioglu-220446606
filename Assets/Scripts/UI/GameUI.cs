using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);

        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.OnCoreHealthChanged.AddListener(UpdateHealthBar);
            GameEventManager.Instance.OnCoreDestroyed.AddListener(ShowLosePanel);
            GameEventManager.Instance.OnGameWon.AddListener(ShowWinPanel);
        }
        else
        {
            Debug.LogError("GameEventManager Instance is null!");
        }
    }

    private void UpdateHealthBar(float percent)
    {
        if (healthBar) healthBar.value = percent;
    }

    private void ShowWinPanel()
    {
        if (winPanel) winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ShowLosePanel()
    {
        if (losePanel) losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}