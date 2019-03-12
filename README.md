## Mahjong-Waiting-Tiles-TDD

這是一個判斷麻將聽哪些牌的程式。給定一副麻將的手牌，會回傳聽哪幾張牌。支援萬筒條東西南北中發白。整個程式以TDD的方式開發。
此程式是個Library Class，建議從Hand開始讀起。


## 類別職責說明
- Hand
  - 一手牌，裡面會包含多張麻將牌(Tiles)
  - 計算出聽哪些牌並回傳
- Tile
  - 代表一張麻將的類別，可以代表東南西北中發白
- WinningDecider
  - 判斷一副牌是否胡牌
- PossibleWaitingTilesGenerator
  - 給定一副手牌，回傳所有"可能"聽的牌，以供嘗試計算是否為真正聽的牌。
- DistinctTileTakenEyeGenerator
  - 給定一副手牌，回傳多組手牌。每組手牌都是輸入手牌拿掉一對眼鏡（相同的牌）的狀態之一。多組手牌中並不重複。
- ComposedByTripletAndSequenceDecider
  - 給定一副手牌，判斷該手牌是否完全都由順子或刻子組成。順子是三張連續的牌，刻子是三張一樣的牌。
