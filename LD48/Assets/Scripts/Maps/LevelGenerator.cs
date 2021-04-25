using System.Collections;
using System.Collections.Generic;
using Maps;
using UnityEngine;

public class LevelGenerator
{
    public ColorMapping[] colorDictionary;
    public Transform parentGrid;

    private GameObject currentLevel;
    private GameObject level;


    public LevelGenerator (ColorMapping[] colorDictionary, Transform grid, GameObject Level)
    {
        this.colorDictionary = colorDictionary;
        this.parentGrid = grid;
        this.level = Level;
    }

    public int generate(int origin, Texture2D sourceTex)
    {
        try
        {
            int negativeOffset = (origin - sourceTex.height);

            currentLevel = GameObject.Instantiate((level), new Vector2(0, negativeOffset), Quaternion.identity, parentGrid);


            for (int x = 0; x < sourceTex.width; x++)
            {
                for (int y = 0; y < sourceTex.height; y++)
                {
                    generateObj(x, y, negativeOffset, sourceTex);
                }
            }
            return negativeOffset;
        } 
        catch (System.NullReferenceException)
        {
            return origin;
        }
    }

    private void generateObj (int x, int y, int offset, Texture2D tex)
    {
        Color color = tex.GetPixel(x, y);
        
        if (color.a == 0)
        {
            return;
        }

        foreach (ColorMapping entry in colorDictionary)
        {
            if (entry.color.Equals(color))
            {
                Vector2 vector2 = new Vector2(x, y + offset);
                try
                {
                    GameObject.Instantiate(entry.GetRandomPrefab(), vector2, Quaternion.identity, currentLevel.transform);
                } catch (System.Exception) { }
            }
        }
    }
}
