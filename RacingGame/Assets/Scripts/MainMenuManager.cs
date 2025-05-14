using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas TrackSelector;
    public Canvas Garage;
    public Canvas CarMarket;
    public Canvas Options;
    [SerializeField] private TMP_Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        OnMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrackSelector()
    {
        if(PlayerStats.Car > -1)
        {
            MainMenu.enabled = false;
            TrackSelector.enabled = true;
            Garage.enabled = false;
            CarMarket.enabled = false;
            Options.enabled = false;
        }
        else
        {
            errorText.text = "You must buy a car first.";
            StartCoroutine(WaitForSeconds(3));
        }
    }

    public void OnGarage()
    {
        MainMenu.enabled = false;
        TrackSelector.enabled = false;
        Garage.enabled = true;
        CarMarket.enabled = false;
        Options.enabled = false;
    }

    public void OnCarMarket()
    {
        MainMenu.enabled = false;
        TrackSelector.enabled = false;
        Garage.enabled = false;
        CarMarket.enabled = true;
        Options.enabled = false;
    }

    public void OnOptions()
    {
        MainMenu.enabled = false;
        TrackSelector.enabled = false;
        Garage.enabled = false;
        CarMarket.enabled = false;
        Options.enabled = true;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        MainMenu.enabled = true;
        TrackSelector.enabled = false;
        Garage.enabled = false;
        CarMarket.enabled = false;
        Options.enabled = false;
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        errorText.text = "";
    }
}
