using System;
using UnityEngine;

public class Interagir : MonoBehaviour{
    
    public GameObject Interacao;
    public GameObject Icone;
    public bool Perto;
    public KeyCode Input1;

    protected virtual void Update(){
        if (Perto && Input.GetKeyDown(Input1) && !Caixa_Dialogo.Ativa){
            Interacao.SetActive(true);
        }
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = true;
            Icone.SetActive(true);
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = false;
            Icone.SetActive(false);
        }
    }
}