using System;



public class CoinScript {
    public static int hoge = 0;

    public void SetPoint(int sum) {
        hoge = sum;
    }

    public void AddCoin() {
        hoge  += 1;
    }

    public int getPoint() {
        return hoge;
    }
}
