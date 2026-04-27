using UnityEngine;

public class Pause : MonoBehaviour{
    public static Pause Instancia;

    public GameObject Tela;
    private bool Pausado = false;

    void Awake(){
        Instancia = this;
        
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Esc();
        }
    }

    public void Esc(){
        Pausado = !Pausado;

        Time.timeScale = Pausado ? 0:1;
        UI.Instancia.AtivarPause(Pausado);
    }
    public void Retomar(){
        Pausado = false;
        Time.timeScale = 1;
        UI.Instancia.AtivarPause(Pausado);
    }
    public void Sair(){
        Time.timeScale = 1;
        Fade.Instancia.TrocarCena("Menu");
    }
}
