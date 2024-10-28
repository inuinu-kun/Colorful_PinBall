using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Physics.autoSimulation = true;
        enabled = true;
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Illumiball");
    }

}
