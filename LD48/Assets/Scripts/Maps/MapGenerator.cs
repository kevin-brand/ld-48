using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Texture2D StartLevel;
    public Transform cam;
    public GameObject Level;
    //public Windows.Directory source // in case we make it even easier to include more levels
    // or more Arrays, one per difficulty
    public Texture2D[] Levels;
    public int difficultyIncreaseAt;
    public ColorDictionary[] colorDictionary;
    public Transform Grid;

    private int lastDepth = 0;
    private LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = new LevelGenerator(colorDictionary, Grid, Level);
        //read levels, incase we make that even easier
        lastDepth = levelGenerator.generate(lastDepth, StartLevel);
        lastDepth = levelGenerator.generate(lastDepth, getFittingLevel());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastDepth - cam.position.y) > -100)
        {
            lastDepth = levelGenerator.generate(lastDepth, getFittingLevel());
        }
    }

    private Texture2D getFittingLevel()
    {
        try
        {
            int r = Random.Range(0, Levels.Length);
            return Levels[r];
        } 
        catch (System.Exception)
        {
            return null;
        }       
    }
}
