using UnityEngine;

public class Inimigo : MonoBehaviour{
    public int Vida;
    protected Rigidbody2D Body;
    protected Collider2D[] Colliders;

    public bool Derrotado = false;

    void Awake(){
        Body = GetComponent<Rigidbody2D>();
        Colliders = GetComponentsInChildren<Collider2D>();
    }
    public void TomarDano(int Dano){
        Vida -= Dano;
        if(Vida <= 0){
            Morrer();
        }
    }

    protected virtual void Morrer(){
        Derrotado = true;

        if (Body != null){
            Body.linearVelocity = Vector2.zero;
            Body.simulated = false;
        }
        foreach (Collider2D C in Colliders){
            C.enabled = false;
        }

        this.enabled = false;
    }
}
