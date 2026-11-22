using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinPoint = 10; // 設定：金幣 1000、銀幣 100、銅幣 10
    GameObject player;

    void Start()
    {
        this.player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 碰撞偵測
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; // 掉落物半徑
        float r2 = 1.0f; // 玩家半徑

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().increasePoint(this.coinPoint); // 傳入coin對應分數

            Destroy(gameObject); // 碰到刪除物件
        }
    }
}
