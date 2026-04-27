using UnityEngine;

public class FimFase1: MonoBehaviour{
    public string ProximaCena;
    public string ProximaFase;
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Geral.Instancia.FaseAtual = ProximaFase;
            SaveManager.Instancia.Salvar();
            Fade.Instancia.TrocarCena(ProximaCena);
        }
    }
}
