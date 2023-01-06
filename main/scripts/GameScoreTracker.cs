using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreTracker : Singletone<GameScoreTracker>
{
    private int _ballCount;

    public int Score { get; set; }

    [SerializeField] private LvlObject _lvlObject;
    [SerializeField] private GameSimulation _gameSimulation;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Text _endText;

    private void Start()
    {
        _ballCount = _gameSimulation.Balls.Length;
        StartCoroutine(WaitUntilScore());
    }

    private IEnumerator WaitUntilScore()
    {
        yield return new WaitUntil(() => Score == _ballCount);

        _restartBtn.gameObject.SetActive(false);
        _nextBtn.gameObject.SetActive(true);
        _endText.gameObject.SetActive(true);
        _lvlObject.IsComplite = true;
        PlayerPrefs.SetInt("IsLvlComplite" + _lvlObject.SceneIndex, 1);
        YandexSDK.Instance.ShowCommonAdvertisment();
    }
}
