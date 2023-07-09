using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDisplayer : MonoBehaviour
{
    [SerializeField] private Levels levelInfo;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private List<GameObject> stars = new List<GameObject>();

    public void Initialize(Levels info)
    {
        levelInfo = info;
        title.text = levelInfo.GetLevelName();

        if (levelInfo.GetLocked() == true)
            this.gameObject.GetComponent<Button>().interactable = false;
        else
            this.gameObject.GetComponent<Button>().interactable = true;

        RatingChecker();
    }
    private void RatingChecker()
    {
        int rating = levelInfo.GetRating();

        for (int i = 0; i < rating; i++)
        {
            stars[i].GetComponent<Image>().color = Color.yellow;
        }
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(levelInfo.GetSceneID());
    }
}
