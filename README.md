# FiveMinutePulse - NinjaTrader Indicator

## Overview
`FiveMinutePulse` is a **NinjaTrader 8** indicator designed to **highlight the second 5-minute bar within each 15-minute period**. This helps traders analyze **intraday price action**, particularly momentum shifts and short-term market structure within larger timeframes.

### Features
- Identifies the **second 5-minute bar** in each **15-minute period**.
- Highlights bars **yellow** for bullish candles, **transparent** for bearish.
- Helps traders spot **momentum shifts, breakouts, and reversals** more effectively.

---

## Understanding the Impact of FiveMinutePulse on Market Analysis
### Identifying Key Bars Within a Larger Structure
- **Why the Second 5-Minute Bar?**  
  Each 15-minute period is composed of three **5-minute bars**. The second bar often represents a **reaction point** where:
  - The market either **continues momentum** from the first bar.
  - A potential **retracement or reversal** occurs before the third bar confirms the direction.

- **Significance in Price Action**  
  - If the second bar **closes strongly in the direction of the first bar**, it suggests **momentum continuation**.
  - If the second bar **retraces**, it may indicate **absorption of orders** or early profit-taking.
  - If it **fails to continue**, traders can look for **reversals or range formations**.

### Practical Trading Applications
- **Momentum Trading**: A strong second 5-minute bar suggests **continuation**.
- **Breakout Confirmation**: If it closes above the first bar’s high, it supports a **breakout**.
- **Reversal Trading**: A weak second bar may signal **reversal potential**.

---

## Installation
### 1. Download or Clone the Repository
```sh
git clone https://github.com/YSFKDR/FiveMinutePulse.git
```

### 2. Import the Indicator into NinjaTrader 8
- Open **NinjaTrader 8**.
- Go to **Tools** > **Import** > **NinjaScript Add-On**.
- Select the `.cs` file (`FiveMinutePulse.cs`) and import it.

### 3. Enable the Indicator
- Open a chart in NinjaTrader.
- Go to **Indicators** (Ctrl + I).
- Search for `FiveMinutePulse` and add it to the chart.
- Click **Apply** and **OK**.

---

## License
This project is licensed under the **MIT License** – free to use and modify.
