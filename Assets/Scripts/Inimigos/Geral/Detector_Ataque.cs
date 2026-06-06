using UnityEngine;

public class Detector_Ataque : MonoBehaviour{
   public bool JogadorNoAlcance;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Jogador")){JogadorNoAlcance = true;}
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Jogador")){JogadorNoAlcance = false;}     
    }
}