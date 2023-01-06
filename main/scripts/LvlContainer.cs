using UnityEngine;

public class LvlContainer : Singletone<LvlContainer>
{
    public LvlItem[] LvlItems;

    private void Start()
    {
        for (int i = 0; i < LvlItems.Length; i++)
        {
            LvlItems[i]._lvlObject.IsComplite = PlayerPrefs.GetInt("IsLvlComplite" + LvlItems[i]._lvlObject.SceneIndex) == 1 ? true : false;
        }
    }
}
