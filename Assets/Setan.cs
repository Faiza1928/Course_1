using UnityEngine;

public class Setan : MonoBehaviour
{
    public string namaSetan;
    public string tujuanSetan;
    public string[] dialogSetan;

    public void Speak()
    {
        Debug.Log(namaSetan + " ingin pergi ke " + tujuanSetan);
    }

    public string[] GetDialog()
    {
        return dialogSetan;
    }
    
}