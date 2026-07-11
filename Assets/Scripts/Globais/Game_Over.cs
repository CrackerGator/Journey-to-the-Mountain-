using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour{
    private string Fase;
    public GameObject Tela;

    void Start(){
        Fase = Geral.Instancia.FaseAtual;
    }
    public void Continuar(){
        Time.timeScale = 1;
        Fade.Instancia.TrocarCena(Fase);
    }
    public void Desistir(){
        Time.timeScale = 1;
        Fade.Instancia.TrocarCena("Menu");
    }
}