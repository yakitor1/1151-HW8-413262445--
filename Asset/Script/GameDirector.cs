using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject moneyText;
    GameObject timeText;
    public GameObject wonText;  
    public GameObject loseText;  
    public GameObject feverText;
    public GameObject fastText;
    public CoinGenerator coinGenerator;

    int money = 0;
    float time = 45.0f;

    void Start()
    {
        this.moneyText = GameObject.Find("point");
        this.timeText = GameObject.Find("time");
        this.moneyText.GetComponent<TextMeshProUGUI>().text = "$0 / 15000";

        this.feverText.SetActive(false);
        this.wonText.SetActive(false);
        this.loseText.SetActive(false);
        this.fastText.SetActive(false);
    }

    public void increasePoint(int point)
    {
        this.money += point;
        this.moneyText.GetComponent<TextMeshProUGUI>().text = "$" + this.money.ToString() + " / 15000";
    }

    void Update()
    {
        this.time -= Time.deltaTime;

        // 時間結束，停止遊戲
        if (this.time <= 0)
        {
            this.time = 0;
            Time.timeScale = 0; 
            this.feverText.SetActive(false);

            // 把畫面所有硬幣刪除
            CoinController[] allCoins = FindObjectsByType<CoinController>(FindObjectsSortMode.None);
            foreach (CoinController coin in allCoins)
            {
                Destroy(coin.gameObject);
            }

            // 分數是否超過15000
            if (this.money > 15000)
            {
                this.wonText.SetActive(true); // 贏
            }
            else
            {
                this.loseText.SetActive(true); // 輸
            }

        }
        // 小於 10 秒：金幣狂潮（極快生成 + 100% 全金幣 + 顯示 UI）
        else if (this.time < 10.0f)
        {
            this.coinGenerator.span = 0.6f;
            this.coinGenerator.goldRate = 10;

            this.feverText.SetActive(true);
            if(this.time < 5.0f)
            {
                this.feverText.SetActive(false);
            }
        }
        // 小於 25 秒：生成間隔變快
        else if (this.time < 25.0f)
        {
            this.coinGenerator.span = 0.8f; // 時間小於25秒，生成間隔0.8秒

            this.fastText.SetActive(true);
            if(this.time < 20.0f)
            {
                this.fastText.SetActive(false);
            }
        }

         // 更新倒數時間
         this.timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + this.time.ToString("F1");
    }
}
