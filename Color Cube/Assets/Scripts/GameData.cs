using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData{

    private static float rotationSensitivity, movementSensitivity, musicVolume;

    public static float RotationSensitivity
    {
        get
        {
            return rotationSensitivity;
        }
        set
        {
            rotationSensitivity = value;
        }
    }
    public static float MovementSensitivity
    {
        get
        {
            return movementSensitivity;
        }
        set
        {
            movementSensitivity = value;
        }
    }
    public static float MusicVolume
    {
        get
        {
            return musicVolume;
        }
        set
        {
            musicVolume = value;
        }
    }


}
