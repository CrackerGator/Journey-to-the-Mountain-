using UnityEngine;
using UnityEngine.UI;

public class UI_Nome : MonoBehaviour{

public InputField InputNome;
public static bool Confirmado = false;

public void botao(){
        Geral.Instancia.NomeJogador = InputNome.text;
        Confirmado = true;
        gameObject.SetActive(false);
    }
}