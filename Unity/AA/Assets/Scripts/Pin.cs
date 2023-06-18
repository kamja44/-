using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()// FixdeUpdate <- 고정된 주기로 호출한다.
    {
        if (isPinned == false && isLaunched == true)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPinned = true;
        if (other.gameObject.tag == "Target")
        {
            // 이름으로 자식 오브젝트 가져오기
            GameObject childObject = transform.Find("Square").gameObject;
            // 인덱스로 자식 오브젝트 가져오기
            // GameObject childObject = transform.GetChild(0).gameObject;
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true;

            transform.SetParent(other.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        }
        else if (other.gameObject.tag == "Pin")
        {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch()
    {
        isLaunched = true;
    }
}
