using UnityEngine;

public class Interagir : MonoBehaviour{
    
    public GameObject Interacao;
    public bool Perto;

    void Update(){
        if (Perto && Input.GetKeyDown(KeyCode.Q) && !Caixa_Dialogo.Ativa){
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