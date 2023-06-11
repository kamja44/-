using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // 변수에 SerializeField를 설정하면 접근 제한자에 상관없이 유니티에서 직접 값을 설정해 줄 수 있다.
    private float moveSpeed;
    [SerializeField]
    private GameObject[] weapons; // GameObject라는 타입이 있음
    private int weaponIndex = 0;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    // Update is called once per frame
    void Update()
    {


        /*
        * 키보드로 캐릭터 제어하기
        ** 제어방법 1
        키보드 방향키 좌우 입력시 값을 받는다.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        키보드 방향키 상하 입력시 값을 받는다.
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;
        
        ** 제어방법 2
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= moveTo;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += moveTo;
        }
        */

        /*
        마우스로 캐릭터 제어하기
        */
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        if (GameManager.instance.isGmaeOver == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Time.time = 게임이 시작된 이후로 현재까지 흐른 시간
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
}
