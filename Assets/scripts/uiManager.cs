using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class uiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject WIN;

    [SerializeField] private Button GameOverRestart;

    [SerializeField] private movement Movement;

    [SerializeField] private TextMeshProUGUI muertes;
    public void livestext(int lives) 
    {
        livesText.text = $"Lives: {lives}";

    }

  
    public void GameOverPanel() 
    {
        GameOver.SetActive(true);
        livesText.text = "";
    }

    public void hidePanels()
    {
        GameOver.SetActive(false);
        WIN.SetActive(false);
    }

    private void Start()
    {
        //Movement = FindObjectOfType<movement>;
        GameOverRestart.onClick.AddListener(() => { Movement.Restart(); }); 
    }

    public void winPanel(int Muertes)
    {
        WIN.SetActive(true);
        muertes.text = $"Has Morido: {Muertes}";
        livesText.text = "";
    }
}
