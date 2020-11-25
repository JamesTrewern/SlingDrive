using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using System.IO;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public PublicVariables Variables;
    public GameObject MainMenu;
    public GameObject Options;
    public TMP_Dropdown[] DropDown = new TMP_Dropdown[2];
    public Slider[] Sliders = new Slider[3];
    private int Difficulty = 0, Background = 0, DeathParticles = 0;
    private float Music = 0f, Effects = 0f;

    private void Start()
    {
        if (!(File.Exists("Settings.txt")))
        {
            WriteSettingsToFile(CreateSettingLines());
        }
        else
        {
            ReadSettings();
            UpdatePublicVariables();
            DropDown[0].value = Difficulty;
            DropDown[1].value = Background;
            Sliders[0].value = DeathParticles;
            Sliders[1].value = Music;
            Sliders[2].value = Effects;
        }
        Options.SetActive(false);
    }

    public void Back()
    {
        Difficulty = DropDown[0].value;
        Background = DropDown[1].value;
        DeathParticles = Mathf.RoundToInt(Sliders[0].value);
        Music = Sliders[1].value;
        Effects = Sliders[2].value;
        UpdatePublicVariables();
        WriteSettingsToFile(CreateSettingLines());
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }

    private string[] CreateSettingLines()
    {
        string[] Lines = new string[10];
        switch (Difficulty)
        {
            case 0:
                Lines[0] = "E";
                break;
            case 1:
                Lines[0] = "N";
                break;
            case 2:
                Lines[0] = "H";
                break;

        }
        Lines[1] = Background.ToString();
        Lines[2] = DeathParticles.ToString();
        Lines[3] = Music.ToString();
        Lines[4] = Effects.ToString();
        return Lines;
    }

    private void WriteSettingsToFile(string[] lines)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter ("Settings.txt"))
        {
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }
    }

    private void ReadSettings()
    {
        string[] lines = new string[10];
        int i = 0;
        using (System.IO.StreamReader file = new System.IO.StreamReader("Settings.txt"))
        {
            while (!(file.EndOfStream))
            {
                lines[i] = file.ReadLine();
                i += 1;
            }
        }
        switch (lines[0])
        {
            case "E":
                Difficulty = 0;
                break;
            case "N":
                Difficulty = 1;
                break;
            case "H":
                Difficulty = 2;
                break;
        }
        Background = Int32.Parse(lines[1]);
        DeathParticles = Int32.Parse(lines[2]);
        Music = float.Parse(lines[3]);
        Music = float.Parse(lines[4]);
    }

    private void UpdatePublicVariables()
    {
        Variables.SetDifficulty(Difficulty);
        Variables.SetBackground(Background);
        Variables.SetDeathParticles(DeathParticles);
        Variables.SetMusicVolume(Music);
        Variables.SetEffectsVolume(Effects);
    }

    // Setting File Format
    // Line 1: Diffuclulty, Char: (E,N,H) 'easy normal or hard'
    // Line 2: GameTheme, int(0-1), 'Nebula, Cat'
    // Line 3: Death Particles, int(0-100), 'The number of death Particles'
    // Line 4: Music Volume, float(0-1), 'Represents the Music Volume as a Percent'
    // Line 5: Efffects Volume, float(0-1), 'Represents the Effects Volume as a Percent'
}
