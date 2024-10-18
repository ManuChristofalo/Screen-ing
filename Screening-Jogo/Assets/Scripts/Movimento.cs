using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    private Vector3 entradasJogador; // Variável para armazenar as entradas do jogador
    private CharacterController characterController; // Variável para armazenar o controle do jogador
    private float velocidadeJogador = 4f; // Velocidade do jogador
    private Transform myCamera; // Variável para armazenar a câmera

    private void Awake(){
        characterController = GetComponent<CharacterController>(); // Pega o componente CharacterController do jogador
        myCamera = Camera.main.transform; // Recuperamos a camera principal que está na cena
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z); // Rotaciona o jogador de acordo com a câmera

        entradasJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Pega as entradas do jogador
        entradasJogador = transform.TransformDirection(entradasJogador); // Transforma as entradas do jogador de acordo com a rotação do jogador


        characterController.Move(entradasJogador * velocidadeJogador * Time.deltaTime); // Move o jogador   
        
    }
}
