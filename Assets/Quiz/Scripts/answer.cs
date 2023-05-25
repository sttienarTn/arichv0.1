using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class answer : MonoBehaviour
{
   public bool isCorrect=false;
  public  Questionmangaer questionmanager; 
   public void Answer(){

    if(isCorrect){
        Debug.Log("corret");
        questionmanager.corret();
    }
    else{
          Debug.Log("falase");
        questionmanager.wrong();


    }
   }
}
