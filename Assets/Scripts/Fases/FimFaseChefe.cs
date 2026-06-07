using UnityEngine;

public class FimFaseChefe : MonoBehaviour{
    private Collider2D Collider;
    public Inimigo Chefe;
    public string ProximaCena;
    public string ProximaFase;

    void Start(){
        Collider = GetComponent<Collider2D>();
        Collider.isTrigger = false;
    }
    void Update(){
        if (Chefe.Derrotado){
            Collider.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Geral.Instancia.FaseAtual = ProximaFase;
            SaveManager.Instancia.Salvar();
            FadeBranco.Instancia.TrocarCena(ProximaCena);
        }
    }
}