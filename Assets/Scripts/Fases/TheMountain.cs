using UnityEngine;

public class TheMountain : MonoBehaviour{
    public string ProximaCena;
    public string ProximaFase;
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Geral.Instancia.FaseAtual = ProximaFase;
            SaveManager.Instancia.Salvar();
            FadeBranco.Instancia.TrocarCena(ProximaCena);
        }
    }
}
