using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Ball : MonoBehaviour {

    private GameScoreTracker _tracker;
    [SerializeField] private float _jumpForce;

    private void Start()
    {
        _tracker = GameScoreTracker.Instance;
        GetComponent<Image>().sprite = ActiveBall.Instance.ActiveBallObject.BallSprite;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            _tracker.Score++;
        }
        else if (collider.tag == "jumper")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            _tracker.Score--;
        }
    }
}
