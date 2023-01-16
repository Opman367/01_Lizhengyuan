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

    //Added by noel
    public Toggle MYRToggle;
    public Toggle TWDToggle;
    private const float MYRinSGD = 3.27f;
    private const float TWDinSGD = 22.96f;
    private float ConvertedAmount;

    // Start is called before the first frame update
    void Start()
    {
        USDtoggle.isOn = false;
        JapneseYentoggle.isOn = false;
        
        //added by noel
        MYRToggle.isOn = false;
        TWDToggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        

            if (USDtoggle.isOn == true)
            {
                JapneseYentoggle.enabled = false;
                //added by noel
                MYRToggle.enabled = false;
                TWDToggle.enabled = false;
            }
            if (JapneseYentoggle.isOn == true)
            {
                USDtoggle.enabled = false;
                //added by noel
                MYRToggle.enabled = false;
                TWDToggle.enabled = false;
            }
            if (MYRToggle.isOn == true)
            {
                //added by noel
                USDtoggle.enabled = false;
                JapneseYentoggle.enabled = false;
                TWDToggle.enabled = false;
            }
            if (TWDToggle.isOn == true)
            {
                //added by noel
                USDtoggle.enabled = false;
                JapneseYentoggle.enabled = false;
                MYRToggle.enabled = false;
            }
            else
            {
                //added by noel
                USDtoggle.enabled = true;
                JapneseYentoggle.enabled = true;
                MYRToggle.enabled = true;
                TWDToggle.enabled = true;
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
            //added by noel
            if (MYRToggle.isOn == true)
            {
                ConvertedAmount = InputNumber * MYRinSGD;
                ConvertedValue.text = "" + ConvertedAmount + " MYR";
            }
            if (TWDToggle.isOn == true)
            {
                ConvertedAmount = InputNumber * TWDinSGD;
                ConvertedValue.text = "" + ConvertedAmount + " TWD";
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

        //added by noel
        MYRToggle.enabled = true;
        USDtoggle.isOn = false;
        TWDToggle.enabled = true;
        TWDToggle.isOn = false;
    }
}
