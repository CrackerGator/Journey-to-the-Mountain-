using System;
using UnityEngine;

public class Interagir : MonoBehaviour{
    
    public GameObject Interacao;
    public bool Perto;
    public KeyCode Input1;

    void Update(){
        if (Perto && Input.GetKeyDown(Input1) && !Caixa_Dialogo.Ativa){
            Interacao.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){Perto = true;}
    }
    private void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){Perto = false;}
    }
}