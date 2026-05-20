using UnityEngine;

public class Porta_Trancada : MonoBehaviour{
    public int ChavesNecessarias;
    public string ProximaCena;
    public string ProximaFase;

    public SpriteRenderer Sprite1;
    public Sprite SpriteAberta;

    private bool Aberta = false;
    private bool Perto = false;

    void Update(){
        if (!Aberta && Perto && Geral.Instancia.Chaves >= ChavesNecessarias && Input.GetKeyDown(KeyCode.Return)){
            AbrirPorta();
        }
        else if(Aberta && Perto && Input.GetKeyDown(KeyCode.Return)){
            Geral.Instancia.FaseAtual = ProximaFase;
            SaveManager.Instancia.Salvar();
            Fade.Instancia.TrocarCena(ProximaCena);
        }
    }

    void AbrirPorta(){
        Aberta = true;
        Sprite1.sprite = SpriteAberta;

        Debug.Log("Porta aberta!");
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = false;
        }
    }
}
