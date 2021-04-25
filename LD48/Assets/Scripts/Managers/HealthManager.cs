using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthManager : MonoBehaviour
{
    public Image Heart1, Heart2, Heart3;
    public Sprite Full, Half, Empty;
    public Character.CharacterHealth Player;

    private int _lastHealth = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_lastHealth != Player.Health)
        {
            _lastHealth = Player.Health;
            Heart1.sprite = (_lastHealth <= 0) ? Empty : (_lastHealth == 1) ? Half : Full;
            Heart1.sprite = (_lastHealth <= 2) ? Empty : (_lastHealth == 3) ? Half : Full;
            Heart3.sprite = (_lastHealth <= 4) ? Empty : (_lastHealth == 5) ? Half : Full;
        }
    }
}
