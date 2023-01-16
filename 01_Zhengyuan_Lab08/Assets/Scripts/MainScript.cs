using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainScript : MonoBehaviour
{
    [SerializeField] private InputField AmountInputField;
    [SerializeField] private InputField ConvertedValue;
    [SerializeField] private Text DebuggingText;
    [SerializeField] private Toggle USDtoggle;
    [SerializeField] private Toggle JapneseYentoggle;
    private const float USDinSGD = 0.76f;
    private const float YENinSGD = 97.07f;
    private float InputNumber;
    private float ConvertedUSD;
    private float ConvertedYen;

    // Start is called before the first frame update
    void Start()
    {
        USDtoggle.isOn = false;
        JapneseYentoggle.isOn = false;

    }

    // Update is called once per frame
    void Update()
    {

        

            if (USDtoggle.isOn == true)
            {
                JapneseYentoggle.enabled = false;
            }
            else
            {
                JapneseYentoggle.enabled = true;
            }
            if (JapneseYentoggle.isOn == true)
            {
                USDtoggle.enabled = false;
            }
            else
            {
                USDtoggle.enabled = true;
            }

    }
    public void ConvertBtn()
    {
        try
        {
            AmountInputField.readOnly = true;
            InputNumber = float.Parse(AmountInputField.text);
            if (USDtoggle.isOn == true)
            {
                ConvertedUSD = InputNumber * USDinSGD;
                ConvertedValue.text = ConvertedUSD.ToString() + " USD";
            }
            if (JapneseYentoggle.isOn == true)
            {
                ConvertedYen = InputNumber * YENinSGD;
                ConvertedValue.text = ConvertedYen.ToString() + " Yen";
            }
        }
        catch
        {
            DebuggingText.text = "Please Input In The Correct Format";
        }
            
    }
    public void ClearBtn()
    {
        AmountInputField.readOnly = false;
        USDtoggle.enabled = true;
        USDtoggle.isOn = false;
        JapneseYentoggle.enabled = true;
        JapneseYentoggle.isOn = false;
        AmountInputField.text = "";
        ConvertedValue.text = "";
        DebuggingText.text = "Debugging";
    }
}
