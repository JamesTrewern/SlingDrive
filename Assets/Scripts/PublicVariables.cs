using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{
    private static float Score;
    public float GetScore() { return Score; }
    public void SetScore(float NewScore) { Score = NewScore; }

    private static int Difficulty;
    public int GetDifficulty() { return Difficulty; }
    public void SetDifficulty(int NewDiff) { Difficulty = NewDiff;}

    private static int DeathParticles;
    public int GetDeathParticles() { return DeathParticles; }
    public void SetDeathParticles(int NewDeathParticles) { DeathParticles = NewDeathParticles; }

    private static int Background;
    public int GetBackground() { return Background; }
    public void SetBackground(int NewBackground) { Background = NewBackground; }

    private static float MusicVolume;
    public float GetMusicVolume() { return MusicVolume; }
    public void SetMusicVolume(float NewMusicVolume) { MusicVolume = NewMusicVolume; }

    private static float EffectsVolume;
    public float GetEffectsVolume() { return EffectsVolume; }
    public void SetEffectsVolume(float NewEffectsVolume) { EffectsVolume = NewEffectsVolume; }
}
