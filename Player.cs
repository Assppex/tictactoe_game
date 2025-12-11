namespace CrossDotsBlazor;
public enum Type_of_side
{
    None = 0,
    Crosses = 1, // 'X'
    Dots = 2  // 'O'
}

public class Player
{
    public string Name { get; private set; }
    public Type_of_side Side { get; private set; }

    public Player(string name, Type_of_side side)
    {
        Name = name;
        Side = side;
    }

    // Меняем сторону игрока
    public void SwapSide()
    {
        Side = Side == Type_of_side.Crosses ? Type_of_side.Dots : Type_of_side.Crosses;
    }

    // Символ для отображения
    public char Symbol => Side == Type_of_side.Crosses ? 'X' : Side == Type_of_side.Dots ? 'O' : ' ';
}