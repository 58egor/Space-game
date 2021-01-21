using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Text scoreLabel;
    public Image menu;
    public Button startButton;
    public static int score = 0;
    public static bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate
        {
            menu.gameObject.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score:" + score;
    }
}
