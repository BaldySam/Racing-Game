using UnityEngine;

public class CarColourEditor : MonoBehaviour
{
    [SerializeField] private Material carMaterial;
    [SerializeField] private Color carColour;
    // Start is called before the first frame update
    void Start()
    {
        carMaterial.color = carColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
