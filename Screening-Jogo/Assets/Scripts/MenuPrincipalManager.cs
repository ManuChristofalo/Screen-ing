using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string jogar;
    [SerializeField] private GameObject painelMenuPrincipal;  
    [SerializeField] private GameObject painelTutorial;

    void Update()
    {
        // Detecta se a tecla "Q" foi pressionada
        if (Input.GetKeyDown(KeyCode.Q) && painelTutorial.activeSelf)
        {
            FecharTutorial();
        }
    }

    public void IniciarJogo()
    {
        // carrega a cena do jogo
        SceneManager.LoadScene(jogar);
    }

    public void AbrirTutorial()
    {
        // carrega a cena do tutorial
        painelMenuPrincipal.SetActive(false);
        painelTutorial.SetActive(true);
    }

    public void FecharTutorial()
    {
        // carrega a cema do menu principal
        painelMenuPrincipal.SetActive(true);
        painelTutorial.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
