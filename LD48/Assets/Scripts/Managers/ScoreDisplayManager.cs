using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ScoreDisplayManager : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public TMPro.TMP_Text textMeshProGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProGUI.text = ScoreManager.Instance.GetHighscore().ToString();
    }
}
