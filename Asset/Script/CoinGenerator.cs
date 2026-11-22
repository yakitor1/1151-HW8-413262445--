using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject goldPrefab;   // 金幣
    public GameObject silverPrefab; // 銀幣
    public GameObject bronzePrefab; // 銅幣
    public int goldRate = 2; // 金幣生成率(20%)
    public int silverRate = 3; // 銀幣生成率(30%)
    public int bronzeRate = 5; // 銅幣生成率(50%)

    public float span = 1.0f; //生成間隔(1s)
    public float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go;
            int dice = Random.Range(1, 11); // 隨機抽1~10

            if (dice <= goldRate)
            {
                go = Instantiate(goldPrefab);   // 生金幣
            }
            else if (dice <= goldRate+silverRate)
            {
                go = Instantiate(silverPrefab); // 生銀幣
            }
            else
            {
                go = Instantiate(bronzePrefab); // 生銅幣
            }

            // 隨機位置生成
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
