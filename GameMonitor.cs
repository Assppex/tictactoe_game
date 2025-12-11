namespace CrossDotsBlazor;
public class GameMonitor
    {
        public int Size { get; private set; }
        public Type_of_side[,] Board { get; private set; }

        public Player[] Players { get; private set; }
        public Player Current { get; private set; }

        public GameMonitor(int size, string name1, string name2)
        {
            if (size < 3) size = 3;
            Size = size;

            // Создаём пустую доску
            Board = new Type_of_side[Size, Size];
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    Board[y, x] = Type_of_side.None;

            // Создаём игроков
            Players = new Player[]
            {
                new Player(name1, Type_of_side.Crosses),
                new Player(name2, Type_of_side.Dots)
            };
            Current = Players[0];
        }

        // Выполнить ход
        public bool MakeMove(int y, int x)
        {
            if (y < 0 || y >= Size || x < 0 || x >= Size) return false;
            if (Board[y, x] != Type_of_side.None) return false;

            Board[y, x] = Current.Side; // ⚠ Здесь "рисуем" X или O на доске
            return true;
        }

        // Смена текущего игрока
        public void SwitchPlayer()
        {
            Current = Current == Players[0] ? Players[1] : Players[0];
        }

        // Проверка ничьи
        public bool IsDraw()
        {
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    if (Board[y, x] == Type_of_side.None)
                        return false;
            return true;
        }

        // Перезапуск игры
        public void Restart(bool swapSides = false)
        {
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    Board[y, x] = Type_of_side.None;

            if (swapSides)
            {
                Player tmp = Players[0];
                Players[0] = Players[1];
                Players[0].SwapSide();
                
                Players[1] = tmp;
                Players[1].SwapSide();
            }

            Current = Players[0];
        }
    }