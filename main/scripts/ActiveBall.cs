using UnityEngine;

public class ActiveBall : Singletone<ActiveBall>
{
    private BallObject _activeBallObject;
    [SerializeField] private ActiveBallObject _savedBall;
    [SerializeField] private BallObject[] _ballObjects;

    public BallObject ActiveBallObject
    {
        get
        {
            return _activeBallObject;
        }
        set
        {
            _activeBallObject = value;
            _savedBall._activeBallObject = value;
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("IsBallTaken0", 1);
        _activeBallObject = _ballObjects[PlayerPrefs.GetInt("ActiveBall")];
    }
}
