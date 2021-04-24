using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public  Texture2D StartLevel;
    //public Windows.Directory source // in case we make it even easier to include more levels
    public List<List<Texture2D>> Levels;
    public int difficultyIncreaseAt;
    public ColorDictionary[] colorDictionary;

    private int lastDepth = 0;
    private LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = new LevelGenerator();
        levelGenerator.colorDictionary = this.colorDictionary;
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
        
    }

    private Texture2D getFittingLevel()
    {
        // TODO
        return null;
    }
}
