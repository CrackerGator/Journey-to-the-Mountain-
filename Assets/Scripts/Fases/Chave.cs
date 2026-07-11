using UnityEngine;

public class Chave : MonoBehaviour{
    public Porta_Trancada P;
    protected virtual void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            P.AdcionarChave(false);
            Destroy(gameObject);
        }
    }
}