using UnityEngine;
using UnityEngine.UI;

public class Botao_Nome : MonoBehaviour{

public InputField InputNome;
public static bool Confirmado = false;

public void Confirmar(){
        Geral.Instancia.NomeJogador = InputNome.text;
        Confirmado = true;
        gameObject.SetActive(false);
    }
}