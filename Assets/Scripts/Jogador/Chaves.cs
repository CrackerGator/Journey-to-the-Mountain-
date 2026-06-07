using UnityEngine;

public class Chaves : MonoBehaviour{
    public void Coletar(){
        Geral.Instancia.Chaves++;
        Destroy(gameObject);
        Debug.Log("Chaves: " + Geral.Instancia.Chaves);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Coletar();
        }
    }
}