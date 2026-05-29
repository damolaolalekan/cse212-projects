using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move.
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        bool[] dirs = _mazeMap[(_currX, _currY)];

        if (!dirs[0]) // left = index 0
            throw new InvalidOperationException("Can't go that way!");

        var next = (_currX - 1, _currY);

        if (!_mazeMap.ContainsKey(next))
            throw new InvalidOperationException("Can't go that way!");

        _currX --;
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move.
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        bool[] dirs = _mazeMap[(_currX, _currY)];

        if (!dirs[1]) // right = index 1
            throw new InvalidOperationException("Can't go that way!");

        var next = (_currX + 1, _currY);

        if (!_mazeMap.ContainsKey(next))
            throw new InvalidOperationException("Can't go that way!");

        _currX ++;
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move.
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        bool[] dirs = _mazeMap[(_currX, _currY)];

        if (!dirs[2]) // up = index 2
            throw new InvalidOperationException("Can't go that way!");

        var next = (_currX, _currY - 1);

        if (!_mazeMap.ContainsKey(next))
            throw new InvalidOperationException("Can't go that way!");

        _currY --;
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move.
    /// If you can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        bool[] dirs = _mazeMap[(_currX, _currY)];

        if (!dirs[3]) // down = index 3
            throw new InvalidOperationException("Can't go that way!");

        var next = (_currX, _currY + 1);

        if (!_mazeMap.ContainsKey(next))
            throw new InvalidOperationException("Can't go that way!");

        _currY ++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}