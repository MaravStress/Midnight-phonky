using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelsSystem : MonoBehaviour
{
    static string levelSave = "level",pointsSave = "points" ;
    public int level = 1;
    public int points;
    [Header("Config")]
 
    public static int pointMax = 12;
    [Header("UI")]
    public string levelName;
    public TextMeshProUGUI LevelTxt;
    public string poinsName;
    public TextMeshProUGUI poinsTxt;
    public Image bar;

    private void Start() {
        Load();
        update_UI();
    }
    public void AddPoins(int i){
        points += i;
        while(points > level*pointMax){
            points -= level*pointMax;
            level ++;
        }
        if(points < 0 ) points = 0; 

        update_UI();
        Save();
    }

    public void update_UI(){
        LevelTxt.text = levelName+" "+level;
        poinsTxt.text = poinsName+" "+ points +"/"+(level*pointMax);
        bar.fillAmount  =  (float.Parse(points.ToString()) /float.Parse((level*pointMax).ToString()));
    }
    public void Save(){
        PlayerPrefs.SetInt(levelSave,level);
        PlayerPrefs.SetInt(pointsSave,points);
    }
    public void Load(){
       level = PlayerPrefs.GetInt(levelSave,1);
       points = PlayerPrefs.GetInt(pointsSave,0);
    }
}


