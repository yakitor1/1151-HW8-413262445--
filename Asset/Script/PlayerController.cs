using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 10f; // 移動速度
    public float limitX = 7.5f;  // 地圖邊界限制
    int moveDir = 0;             // -1 往左、0 停止、1 往右
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.timeScale == 0) return; // 時間暫停 人物不能動

        // 只要按鈕按住且moveDir不為0，每一幀就會持續移動
        if (this.moveDir != 0)
        {
            this.transform.Translate(this.moveDir * this.moveSpeed * Time.deltaTime, 0, 0);

            // 角色不能超出左右邊界
            Vector3 pos = this.transform.position;
            pos.x = Mathf.Clamp(pos.x, -this.limitX, this.limitX);
            this.transform.position = pos;
        }
    }
    public void LButtonDown()
    {
        if (Time.timeScale == 0) return;
        this.moveDir = -1;
    }
    public void RButtonDown()
    {
        if (Time.timeScale == 0) return;
        this.moveDir = 1;
    }

    // 放開按鈕時，停止移動
    public void ButtonUp()
    {
        this.moveDir = 0;
    }
}
