using UnityEngine;

public class BallMarketContainer : Singletone<BallMarketContainer>
{
    public BallMarket[] _ballMarkets;

    public void RefreshAll()
    {
        foreach (var ball in _ballMarkets)
        {
            ball.Refresh();
        }
    }
}
