using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class versionGame : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private void Awake() {
        txt.SetText("v "+Application.version.ToString());
    }
}
