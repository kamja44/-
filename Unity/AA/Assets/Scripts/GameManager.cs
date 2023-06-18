using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal;


    public int goal;

    [SerializeField]
    private GameObject btnRetry;

    [SerializeField]
    private Color green;
    [SerializeField]
    private Color red;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textGoal.SetText(goal.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecreaseGoal()
    {
        goal -= 1;
        textGoal.SetText(goal.ToString());
        if (goal <= 0)
        {
            SetGameOver(true);
        }
    }
    public void SetGameOver(bool success)
    {
        if (isGameOver == false)
        {
            isGameOver = true;

            Camera.main.backgroundColor = success ? green : red;
            Invoke("ShowRetryButton", 0.5f);
        }
    }
    // 앞에 접근제한자를 명시하지 않으면 기본적으로 private로 정의된다.
    void ShowRetryButton()
    {
        btnRetry.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
