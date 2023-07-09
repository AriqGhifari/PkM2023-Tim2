using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour //May Combine this with Level Manager
{
    public static LevelManager instance;
    public Levels activeLevel;

    [Header("NEXT LEVEL ID IS BASED ON LIST'S ELEMENT")]
    public List<Levels> levels = new List<Levels>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        if (instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        InitializeLevels();
    }
    private void InitializeLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            int nextLevel = levels[i].GetNextLevelID();
            levels[i].InitializeLevel(levels[nextLevel]);
        }
    }
    public void LevelCompleted(int rating)
    {
        activeLevel.LevelCompleted(rating);
        activeLevel = null;
    }
}
