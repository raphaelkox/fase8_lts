using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static float cell_width = 16f;
    public static float cell_height = 10f;
    public static float half_cell_width = 8f;
    public static float half_cell_height = 5f;

    public static Vector2 GetGridPosition(Vector3 position) {
        //var newgridx = Mathf.Floor((position.x + GameManager.half_cell_width) / GameManager.cell_width);
        //var newgridy = Mathf.Floor((position.y + GameManager.half_cell_height) / GameManager.cell_height);
        var newgridx = Mathf.Floor(position.x / GameManager.cell_width);
        var newgridy = Mathf.Floor(position.y / GameManager.cell_height);

        return new Vector2(newgridx, newgridy);
    }
}
