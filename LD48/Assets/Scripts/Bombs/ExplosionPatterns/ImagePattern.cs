using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bombs.ExplosionPatterns
{
    [CreateAssetMenu(fileName = "new Image Pattern", menuName = "Data/Bombs/Image Pattern")]
    public class ImagePattern : ExplosionPattern
    {
        private Vector2[] directions;
        public Texture2D Pattern;
        public override List<Vector2> GetExplosionPositions(Vector2 point)
        {
            ReadImg();
            List<Vector2> explosionPositions = new List<Vector2>();
            explosionPositions.Add(point);
            foreach (var direction in directions)
            {
                Vector2 pos = point + direction;
                explosionPositions.Add(pos);                
            }

            return explosionPositions;
        }

        // Start is called before the first frame update
        private void ReadImg()
        {
            int h = (int)(Pattern.width / 2);
            Debug.Log(h);
            List<Vector2> pat = new List<Vector2>();
            try
            {
                for (int x = 0; x < Pattern.width; x++)
                {
                    for (int y = 0; y < Pattern.height; y++)
                    {
                        if (CompareColors(Pattern.GetPixel(x, y), Color.black)){
                            Debug.Log(x + " + " + y);
                            pat.Add(new Vector2(x - h, y - h));
                        }
                    }
                }
                directions = new Vector2[pat.Count];
                for (int i = 0; i < pat.Count; i++)
                {
                    directions[i] = pat[i];
                }
            }
            catch (System.Exception)
            {
                directions = new Vector2[0];
            }
        }

        private bool CompareColors(Color a, Color b)
        {
            if (a.r - .01f < b.r && b.r < a.r + .01f)
            {
                if (a.g - .01f < b.g && b.g < a.g + .01f)
                {
                    if (a.b - .01f < b.b && b.b < a.b + .01f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

