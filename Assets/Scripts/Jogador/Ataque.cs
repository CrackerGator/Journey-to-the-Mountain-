using UnityEngine;

public class Ataque : MonoBehaviour{
    public int Dano;
    private void OnTriggerEnter2D(Collider2D collider){
        Inimigo I = collider.GetComponentInParent<Inimigo>();
        if(I != null){
            I.TomarDano(Dano);
        }
    }
}