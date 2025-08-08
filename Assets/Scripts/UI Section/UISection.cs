using UnityEngine;

public class UISection : MonoBehaviour
{
    public string SectionID;
    public virtual void OnSectionIN() 
    {
        gameObject.SetActive(true);
    }
    public virtual void OnSectionOUT() 
    {
        gameObject.SetActive(false);
    }
}
