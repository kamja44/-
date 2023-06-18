using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]
    // 음수면 시계 방향으로 회전
    // 양수면 반시계 방향으로 회전
    private float rotateSpeed = -30f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

    }
}
