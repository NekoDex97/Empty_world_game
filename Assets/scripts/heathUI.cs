using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class heathUI : MonoBehaviour
{

    Slider mySlide;
    public Color low;
    public Color high;
    public TextMeshProUGUI count;
    // Start is called before the first frame update
    void Start()
    {
        mySlide = gameObject.GetComponentInChildren<Slider>();
        count = count.GetComponentInChildren<TextMeshProUGUI>();
        //mySlide = GameObject.FindGameObjectWithTag("HpBar");
        
    }


    public void setValue(int i)
    {
        mySlide.value = i;
        mySlide.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, mySlide.normalizedValue); 
    }
    
    public void setCount(int i)
    {
        count.text = i.ToString();
    }
}
