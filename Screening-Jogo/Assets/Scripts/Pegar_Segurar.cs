using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurarEPegarObjetos : MonoBehaviour
{
    public float distanciaMaxima = 4.0f; // Distância máxima para pegar o objeto
    public Transform pontoMao;           // Posição onde o objeto será segurado
    public Transform objetoSegurado;     // Objeto que será segurado
    public LayerMask layer;              // Define quais objetos são interagíveis (ex. objetos na layer "Interagível")

    void Update()
    {
        // Verifica se o jogador pressionou a tecla "E" para pegar o objeto
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            // Lança o Raycast da posição da câmera, verificando a distância e o Layer do objeto
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaMaxima, layer))
            {
                // Verifica se o objeto atingido tem a tag correta
                Debug.Log("Objeto atingido: " + hit.transform.name); // Adiciona log para verificar o Raycast
                if (hit.transform.CompareTag("Pegavel"))
                {
                    PegarObjeto(hit.transform);
                }
            }
        }

        // Solta o objeto se a tecla "Q" for pressionada
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoltarObjeto();
        }
    }

    void PegarObjeto(Transform objeto)
    {
        // Verifica se já está segurando algum objeto
        if (objetoSegurado == null)
        {
            objetoSegurado = objeto;
            Debug.Log("Objeto segurado: " + objetoSegurado.name);  // Verifica se o objeto foi atribuído

            // Desativa o Rigidbody para que o objeto não seja afetado pela física
            if (objetoSegurado.GetComponent<Rigidbody>())
            {
                objetoSegurado.GetComponent<Rigidbody>().isKinematic = true;
            }

            // Define a posição e rotação do objeto para a mão
            objetoSegurado.position = pontoMao.position;
            objetoSegurado.rotation = pontoMao.rotation;

            // Ajuste a distância entre o objeto e a câmera, caso necessário
            Vector3 offset = new Vector3(0, 0, 0.5f); // Exemplo: 0.5f metros à frente do pontoMao
            objetoSegurado.position += pontoMao.forward * offset.z;

            // Define o objeto como filho do pontoMao para que ele siga a mão
            objetoSegurado.SetParent(pontoMao);
        }
    }

    void SoltarObjeto()
    {
        if (objetoSegurado != null)
        {
            // Remove o objeto da mão
            objetoSegurado.SetParent(null);

            // Reativa a física do objeto
            Rigidbody rb = objetoSegurado.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true; // Reativa a gravidade para o objeto voltar ao comportamento normal
            }

            // Limpa a referência do objeto segurado
            objetoSegurado = null;
        }
    }

    // Método adicional para verificar se um objeto está sendo segurado
    public bool EstaSegurandoObjeto()
    {
        return objetoSegurado != null;
    }

    // Método adicional para obter o nome do objeto segurado
    public string ObterNomeObjetoSegurado()
    {
        return objetoSegurado != null ? objetoSegurado.name : "Nenhum objeto";
    }
}
