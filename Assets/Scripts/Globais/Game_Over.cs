using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour{
    private string Fase;

    void Update(){
        Fase = Geral.Instancia.FaseAtual;
    }
    public void Continuar(){
        SceneManager.LoadScene(Fase);
    }

    public void Desistir(){
        SceneManager.LoadScene("Menu");
    }
}
