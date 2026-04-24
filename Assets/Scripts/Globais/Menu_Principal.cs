using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour{
    public void NovoJogo(){
        SceneManager.LoadScene("Cutscene 1.1");
        Geral.Instancia.FaseAtual = "Fase 1.1";
    } 

}
