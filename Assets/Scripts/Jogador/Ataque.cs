using Unity.VisualScripting;
using UnityEngine;

public class Ataque : MonoBehaviour{
    public int Dano;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Inimigo")){
            collision.GetComponent<Inimigo>().TomarDano(Dano);
        }
    }
}