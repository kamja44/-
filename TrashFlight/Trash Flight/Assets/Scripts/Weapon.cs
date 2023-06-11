using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;
    // Start is called before the first frame update
    void Start() // 게임 객체를 비활성화 했다가 다시 활성화 하는 경우에도 호출된다.
    {
        // Destory 함수의 두 번째 매개변수에는 몇초 후에 요소를 삭제할지 정의한다.
        Destroy(gameObject, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
