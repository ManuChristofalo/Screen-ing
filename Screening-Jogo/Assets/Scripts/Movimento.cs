using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Vector3 entradasJogador; // Variável para armazenar as entradas do jogador
    private CharacterController characterController; // Variável para armazenar o controle do jogador
    private float velocidadeJogador = 4f; // Velocidade do jogador
    private Transform myCamera; // Variável para armazenar a câmera
    private float gravidade = -9.81f; // Valor da gravidade
    private float velocidadeVertical = 0f; // Velocidade no eixo vertical (para gravidade)
    private bool noChao; // Verifica se o jogador está no chão

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); // Pega o componente CharacterController do jogador
        myCamera = Camera.main.transform; // Recuperamos a camera principal que está na cena
    }

    void Update()
    {
        // Rotaciona o jogador de acordo com a câmera
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);

        // Pega as entradas do jogador
        entradasJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        entradasJogador = transform.TransformDirection(entradasJogador); // Transforma as entradas do jogador de acordo com a rotação do jogador

        // Verifica se o jogador está no chão
        noChao = characterController.isGrounded;

        // Se o jogador estiver no chão, a velocidade vertical é 0, caso contrário, aplicamos a gravidade
        if (noChao)
        {
            velocidadeVertical = 0f;
        }
        else
        {
            velocidadeVertical += gravidade * Time.deltaTime;
        }

        // Adiciona a gravidade ao movimento vertical
        entradasJogador.y = velocidadeVertical;

        // Move o jogador considerando a gravidade
        characterController.Move(entradasJogador * velocidadeJogador * Time.deltaTime);
    }
}
