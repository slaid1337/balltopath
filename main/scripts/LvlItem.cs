using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlItem : MonoBehaviour
{
    [SerializeField] private Button _lvlButton;
    public LvlObject _lvlObject;

    private void Start()
    {
        _lvlButton.onClick.AddListener(LoadScene);

        if (_lvlObject.SceneIndex != 1)
        {
            if (LvlContainer.Instance.LvlItems[_lvlObject.SceneIndex - 2]._lvlObject.IsComplite)
            {
                _lvlButton.interactable = true;
            }
            else
            {
                _lvlButton.interactable = false;
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_lvlObject.SceneIndex);
    }
}
