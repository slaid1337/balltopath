using UnityEngine;
using UnityEngine.UI;

public class BallMarket : MonoBehaviour
{
    public BallObject _ballObject;
    [SerializeField] private Image _ballImage;
    [SerializeField] private Button _getButton;
    [SerializeField] private Button _setButton;
    [SerializeField] private GameObject _setObject;
    private YandexSDK _yandexSDK;

    private void Start()
    {
        _ballImage.sprite = _ballObject.BallSprite;
        _yandexSDK = YandexSDK.Instance;
        _ballObject.IsTaken = PlayerPrefs.GetInt("IsBallTaken" + _ballObject.BallIndex.ToString()) == 1 ? true : false;
        Refresh();
    }

    public void GetBall()
    {
        _yandexSDK.RewardGet += GetBallFromAds;
        _yandexSDK.RewardStop += StopBallReward;
        _yandexSDK.ShowRewardAdvertisment();
    }

    private void StopBallReward()
    {
        _yandexSDK.RewardGet -= GetBallFromAds;
        _yandexSDK.RewardStop -= StopBallReward;
    }

    private void GetBallFromAds()
    {
        _ballObject.IsTaken = true;
        PlayerPrefs.SetInt("IsBallTaken" + _ballObject.BallIndex.ToString(), 1);
        _yandexSDK.RewardGet -= GetBallFromAds;
        _yandexSDK.RewardStop -= StopBallReward;
        BallMarketContainer.Instance.RefreshAll();
    }

    public void SetBall()
    {
        ActiveBall.Instance.ActiveBallObject = _ballObject;
        PlayerPrefs.SetInt("ActiveBall" , _ballObject.BallIndex);
        BallMarketContainer.Instance.RefreshAll();
    }

    public void Refresh()
    {
        if (_ballObject.IsTaken)
        {
            if (ActiveBall.Instance.ActiveBallObject == _ballObject)
            {
                _getButton.gameObject.SetActive(false);
                _setButton.gameObject.SetActive(false);
                _setObject.SetActive(true);
            }
            else
            {
                _getButton.gameObject.SetActive(false);
                _setButton.gameObject.SetActive(true);
                _setObject.SetActive(false);
            }
        }
        else
        {
            _getButton.gameObject.SetActive(true);
            _setButton.gameObject.SetActive(false);
            _setObject.SetActive(false);
        }
    }
}
