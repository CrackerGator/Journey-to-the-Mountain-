using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour{

    public static Game_Over Instancia;

    private string Fase;
    public GameObject Tela;

    void Awake(){
        Instancia = this;
    }
    void Start(){
        Fase = Geral.Instancia.FaseAtual;
    }
    public void Perdeu(){
        UI.Instancia.AtivarGameOver();
        Time.timeScale = 0;
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
