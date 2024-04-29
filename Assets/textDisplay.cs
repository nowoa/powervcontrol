using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textDisplay : MonoBehaviour
{

    public RuleManager ruleManager;

    public TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateText()
    {
        textField.text = ruleManager.ruleText;
    }
}
