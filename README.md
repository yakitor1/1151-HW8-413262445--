# 1151-HW8-413262445--
撿金幣模擬器

遊戲設置:

角色、金幣(gold,silver,bronze)、UI(LButton/RButton,time,point,win/lose,fever,faster)

腳本設置:

PlayerController 角色移動

GameDirector 導演腳本

CoinController 金幣控制

CoinGenerator 金幣生成

參數設置:
| 遊戲階段 | 剩餘時間 | `span` (生成間隔) | `speed` (掉落物速度) | `rate` (金 / 銀 / 銅 生成機率) |
| :--- | :---: | :---: | :---: | :---: |
| **一般** | 25 ~ 45 秒 | `1.0s` | `-0.1f` | 20% / 30% / 50% |
| **Faster** | 10 ~ 25 秒 | `0.8s` | `-0.1f` | 20% / 30% / 50% |
| **Fever** | 0 ~ 10 秒 | `0.6s` | `-0.f` | 100% / 0% / 0% |

Fever(金幣狂潮): 在最後10秒必定生成金幣

<img width="1912" height="995" alt="image" src="https://github.com/user-attachments/assets/164cb289-27ab-4395-9a9b-719958bad0c1" />
