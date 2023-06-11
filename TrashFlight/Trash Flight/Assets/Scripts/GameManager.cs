using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject gameOverPanel;
    private int coin = 0;

    [HideInInspector]
    public bool isGmaeOver = false;

    // Start() 메서드보다 더 먼저 호출되는 메서드
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());
        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver()
    {
        isGmaeOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPanel", 1f);
    }
    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
