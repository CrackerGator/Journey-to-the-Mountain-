using UnityEngine;
using UnityEngine.UI;

public class Selecionar_Fase : MonoBehaviour{

    public InputField InputCena;

    public void IrParaFase(){
        if(InputCena.text != ""){
            Fade.Instancia.TrocarCena(InputCena.text);
        }
    }
}
