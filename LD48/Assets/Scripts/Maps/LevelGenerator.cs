using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    public ColorDictionary[] colorDictionary;
    public int generate(int origin, Texture2D sourceTex)
    {
        try
        {
            int negativeOffset = (origin - sourceTex.height);

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

        foreach (ColorDictionary entry in colorDictionary)
        {
            if (entry.color.Equals(color))
            {
                Vector2 vector2 = new Vector2(x, y + offset);
                GameObject.Instantiate(entry.prefab, vector2, Quaternion.identity);
            }
        }
    }
}
