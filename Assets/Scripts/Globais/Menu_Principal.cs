using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour{
    public void NovoJogo(){
        Geral.Instancia.ResetarDados();
        SaveManager.Instancia.Salvar();
        Fade.Instancia.TrocarCena("Cutscene 1.1");
    } 
    public void CarregarJogo(){
        if(SaveManager.Instancia.Carregar()){
            Fade.Instancia.TrocarCena(Geral.Instancia.FaseAtual);
        }
    }
}