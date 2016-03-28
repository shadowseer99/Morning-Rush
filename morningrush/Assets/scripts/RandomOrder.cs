using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomOrder : MonoBehaviour
{

    public string[] size;
    public string[] type;
    public string iced;
    public string order;
    public Text orderText;

    // Use this for initialization
    void Start()
    {
        
        string[] size = { "Tall", "Grande", "Venti"};
        string[] type = { "Hot Chocolate", "Vanilla Latte", "Mocha", "White Chocolate Mocha" };
        iced = "Iced";
        string orderSize = size.GetValue(Random.Range(0, 3)).ToString();
        string orderType = type.GetValue(Random.Range(0, 4)).ToString();
        order = orderSize + " " + orderType;
        if (orderType.Equals("Vanilla Latte") || orderType.Equals("Mocha") || orderType.Equals("White Chocolate Mocha"))
        {
            if (Random.Range(0, 2) == 1)
            {
                order = "Iced" + " " + orderType;
            }
        }
        orderText.text = order;
       
    }

    // Update is called once per frame
    
}
