using UnityEngine;

public class Inimigo : MonoBehaviour{
    public int Vida;
    protected Rigidbody2D Body;
    public Collider2D ColliderInimigo;

    public bool Derrotado = false;

    void Awake(){
        Body = GetComponent<Rigidbody2D>();
        ColliderInimigo = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Jogador J = collider.GetComponent<Jogador>();
            if(J != null){
                J.TomarDano(1, transform.position);
            }
        }
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
        if (ColliderInimigo != null){
            ColliderInimigo.enabled = false;
        }

        this.enabled = false;
    }
}
