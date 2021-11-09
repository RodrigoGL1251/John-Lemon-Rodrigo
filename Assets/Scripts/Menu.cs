using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public GameObject panelPortada;
    public GameObject panelLevels;

    // Start is called before the first frame update
    void Start()
    {
        PortadaMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LevelsMenu()
    {
        panelPortada.SetActive(false);
        panelLevels.SetActive(true);
    }

    public void PortadaMenu()
    {
        panelPortada.SetActive(true);
        panelLevels.SetActive(false);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
