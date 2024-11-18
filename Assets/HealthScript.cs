using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _health;
    public TMP_Text _money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _health.text = balloonMove.playerHealth.ToString();
        _money.text = mouseSelector.money.ToString();
    }
}
