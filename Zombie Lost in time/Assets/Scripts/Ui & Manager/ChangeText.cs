using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public TMP_Text initialValue;
    public float valueToAdd;

    private float value;

    private void Start()
    {
        // Imposta il valore iniziale dal valore settato nell'Editor
        float.TryParse(initialValue.text, out value);

        // Assegna il valore iniziale al testo
        textMeshPro.text = value.ToString();
    }

    public void AddValue()
    {
        // Aggiungi il valore da settare nell'Editor al valore corrente
        value += valueToAdd;

        // Assegna il nuovo valore al testo
        textMeshPro.text = value.ToString();
    }
}



