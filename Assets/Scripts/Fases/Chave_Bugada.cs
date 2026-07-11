using UnityEngine;

public class Chave_Bugada : Chave{
    public bool Bugado = false;
    private SpriteRenderer Sprite1;
    public Sprite SpriteBugado;
    public GameObject Dialogo;

    void Start(){
        Sprite1 = GetComponent<SpriteRenderer>();
        if(Geral.Instancia.NomeJogador != "??????"){
            Bugado = true;
            Sprite1.sprite = SpriteBugado;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            if(Bugado == true){
                Dialogo.SetActive(true);
            }
            P.AdcionarChave(Bugado);
            Destroy(gameObject);
        }
    }
}