using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K : MonoBehaviour
{
    public const int LAYER_MAINCHAR = 8;
    public const int LAYER_ENEMY = 9;
    public const int LAYER_HAZARD = 10;
    public const int LAYER_FLOOR = 11;
    public const int LAYER_WALL = 12;
    public const int LAYER_ITEM = 13;
    public const int LAYER_FALLDEATH = 14;

    public static Vector3[] recolors = {
        new Vector3(0, 1, 1),
        new Vector3(60, 1.2f, 1),
        new Vector3(120, 2, 1.35f),
        new Vector3(180, 1.3f, 1.2f),
        new Vector3(240, 1.25f, 1.2f),
        new Vector3(300, 2, 1.3f)};

    public static int[] scoreListing = {
        0,
        1500,
        3500,
        7250,
        12500,
        20000};
}
