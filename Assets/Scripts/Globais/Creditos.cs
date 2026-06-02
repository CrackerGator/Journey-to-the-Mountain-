using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour{

    public GameObject Logo;
    public GameObject Texto;

    private int i = 0;

    void Start(){
        Logo.SetActive(true);
        Texto.SetActive(false);
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            switch(i){
                case 0:
                    Logo.SetActive(false);
                    Texto.SetActive(true);
                    i++;
                break;

                case 1:
                    SceneManager.LoadScene("Menu");
                break;
            }
        }
    }
}