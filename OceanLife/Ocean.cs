using System.Collections;
using System.Runtime.CompilerServices;

namespace OceanLife;

public class Ocean
{
    #region varaibles

        private Cell[,] _cells;
        private int _size;
        protected int _numPrey;
        protected int _numObstacles;
        protected int _numPredators;

    #endregion

    #region default ctors

        public Ocean()
        {
            _cells = new Cell[Consts.OCEAN_NUM_COLS, Consts.OCEAN_NUM_ROWS];
            _size = _cells.Length;
            _numPrey = Consts.DEFAULT_NUM_PREY;
            _numObstacles = Consts.DEFAULT_NUM_OBSTACLES;
            _numPredators = Consts.DEFAULT_NUM_PREDATORS;
        }

    #endregion

    #region TODO

        // TODO: optimize code
        // TODO: refactor code
        // TODO: create interface to show preys and sharks
        // TODO: create own exceptions

    #endregion

    #region props

        public Cell[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Cell this[Coordinates coord]
        {
            get => _cells[coord.X, coord.Y];
            set => _cells[coord.X, coord.Y] = value;
        }

        public int NumPrey
        {
            get
            {
                if (_numPrey < 0)
                {
                    return 0;
                }

                return _numPrey;
            }
            set
            {
                if (_numPrey < 0)
                {
                    return;
                }

                _numPrey = value;
            }
        }

        public int NumObstacles
        {
            get
            {
                if (_numObstacles < 0)
                {
                    return 0;
                }

                return _numObstacles;
            }
            set
            {
                if (_numObstacles < 0 || _numObstacles > _size)
                {
                    return;
                }

                _numObstacles = value;
            }
        }

        public int NumPredator
        {
            get
            {
                if (_numPredators < 0)
                {
                    return 0;
                }

                return _numPredators;
            }
            set
            {
                if (_numPredators < 0)
                {
                    return;
                }

                _numPrey = value;
            }
        }

    #endregion

    public void Init()
    {
        for (int i = 0; i < _numPrey; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Prey(coord);
        }

        for (int i = 0; i < _numPredators; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Predator(coord);
        }

        for (int i = 0; i < _numObstacles; i++)
        {
            Coordinates coord = GetRandomCoordinate();

            _cells[coord.X, coord.Y] = new Obstacle(coord);
        }
    }

    public void Update()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] != null)
                {
                    if (i != _cells[i, k].Coord.X || k != _cells[i, k].Coord.Y)
                    {
                        Cell temp = _cells[i, k];
                        _cells[temp.Coord.X, temp.Coord.Y] = temp;
                        _cells[i, k] = null!;
                    }
                }
            }
        }

        CheckCellsPositions();
        SyncNumbersOfFish();
    }

    public void MoveNextIteration()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Predator)
                {
                    _cells[i, k].ReduceTimeToFeed();
                    
                    if (_cells[i, k].GetTimeToFeed() == 0)
                    {
                        _cells[i, k] = null!;
                        _numPredators--;

                        continue;
                    }

                    if (_cells[i, k].GetTimeToReproduce() == 0)
                    {
                        AddPredator();
                    }

                    if (_cells[i, k].DoesShartkillInIteration() == true)
                    {
                        _cells[i, k].SetSharkKill(false);
                    }
                }

                if (_cells[i, k] is Prey)
                {
                    _cells[i, k].ReduceTimeToReproduce();

                    if (_cells[i, k].GetTimeToReproduce() == 0)
                    {
                        AddPrey();
                    }

                    continue;
                }
            }
        }
    }

    public void SyncNumbersOfFish()
    {
        int numPrey = 0;
        int numPredator = 0;

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Predator)
                {
                    numPredator++;
                    
                    continue;
                }
                
                if (_cells[i, k] is Prey)
                {
                    numPrey++;
                }
            }
        }

        if (_numPrey != numPrey)
        {
            string s = ("_numPrey {0} != numPrey {1}", _numPrey, numPrey).ToString();
            throw new ArithmeticException(s);
        }

        if (_numPredators != numPredator)
        {
            string s = ("_numPredators {0} != numPredator {1}", _numPredators, numPredator).ToString();
            throw new ArithmeticException(s);
        }
    }

    #region Add

    // TODO: add try catch

        public void AddPrey(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {
                _numPrey += num;
        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Prey(coord);
                    }
                }
            }
        }
    
        public void AddPrey()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Prey(coord);
    
                    _numPrey++;
                }
            }
        }
    
        public void AddPredator(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Predator(coord);

                        _numPredators++;
                    }
                }
            }
        }
    
        public void AddPredator()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Predator(coord);
    
                    _numPredators++;
                }
            }
        }
    
        public void AddObstacles(int num)
        {
            if ((_numPrey + num + _numObstacles + _numPredators) < _size)
            {
        
                for (int i = 0; i < num; i++)
                {
                    if (!IsFullCells())
                    {
                        Coordinates coord = GetRandomCoordinate();
            
                        _cells[coord.X, coord.Y] = new Obstacle(coord);

                        _numObstacles++;
                    }
                }
            }
        }
    
        public void AddObstacles()
        {
            if ((_numPrey + 1 + _numObstacles + _numPredators) < _size)
            {
                if (!IsFullCells())
                {
                    Coordinates coord = GetRandomCoordinate();
        
                    _cells[coord.X, coord.Y] = new Obstacle(coord);
    
                    _numObstacles++;
                }
            }
        }
    
    #endregion

    private Coordinates GetRandomCoordinate()
    {
        Coordinates coord = new Coordinates();
        
        coord.X = BL.GetRandomInt(1, _cells.GetLength(0));
        coord.Y = BL.GetRandomInt(1, _cells.GetLength(1));

        if (!IsEmptyCell(coord))
        {
            return GetRandomCoordinate();
        }

        return coord;
    }

    private bool IsEmptyCell(Coordinates coord)
    {
        if (_cells[coord.X, coord.Y] == null)
        {
            return true;
        }

        return false;
    }

    private bool IsEmptyCell(int x, int y)
    {
        if (_cells[x, y] == null)
        {
            return true;
        }

        return false;
    }

    private bool IsFullCells()
    {
        if ((_numObstacles + _numPredators + _numPrey) >= _size)
        {
            return true;
        }

        return false;
    }

    private void CheckCellsPositions()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] != null && (i != _cells[i, k].Coord.X || k != _cells[i, k].Coord.Y))
                {
                    string s = ("Indexes are not equal to coords i = ", i, "k = ", k, 
                        "Coord.X = ", _cells[i, k].Coord.X, "Coord.Y = ", _cells[i, k].Coord.Y). ToString();
                    throw new Exception(s);
                }
            }
        }
    }

    #region GetCellInfo

        private Movement GetEmptyNeighbor(Cell c)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;
    
            Movement[] movements = new Movement[0];
    
            try
            {
                if (IsEmptyCell(x, y + 1) && y < Consts.OCEAN_NUM_ROWS)
                {
                    AddMovementsArray(ref movements, Movement.Up);
                }
        
                if (IsEmptyCell(x, y - 1) && y > 0)
                {
                    AddMovementsArray(ref movements, Movement.Down);
                }
        
                if (IsEmptyCell(x + 1, y) && x < Consts.OCEAN_NUM_COLS)
                {
                    AddMovementsArray(ref movements, Movement.Right);
                }
        
                if (IsEmptyCell(x - 1, y) && x > 0)
                {
                    AddMovementsArray(ref movements, Movement.Left);
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                return Movement.None;
            }
    
            if (movements.Length == 0)
            {
                return Movement.None;
            }
    
            if (movements.Length == 1)
            {
                return movements[0];
            }
    
            int index = BL.GetRandomInt(0, movements.Length - 1);
    
            return movements[index];
        }
    
        private void AddMovementsArray(ref Movement[] movements, Movement m)
        {
            Array.Resize(ref movements, movements.Length + 1);
    
            movements[movements.Length - 1] = m;
        }

        private Coordinates GetCoordToMove(Cell c, Movement direction)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;

            if (direction == Movement.Up)
            {
                return new Coordinates(x, y + 1);
            }

            if (direction == Movement.Down)
            {
                return new Coordinates(x, y - 1);
            }

            if (direction == Movement.Right)
            {
                return new Coordinates(x + 1, y);
            }

            if (direction == Movement.Left)
            {
                return new Coordinates(x - 1, y);
            }

            return new Coordinates(x, y);
        } 

        private Movement GetPreyNeighbor(ref Cell c)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;
    
            Movement[] movements = new Movement[0];
    
            try
            {
                if (_cells[x, y + 1] is Prey && _cells[x, y + 1] is not Predator && y < Consts.OCEAN_NUM_ROWS)
                {
                    KillPrey(_cells[x, y + 1], ref _cells[x, y]);
                    c.RestartTimeToFeed();

                    AddMovementsArray(ref movements, Movement.Up);
                }
        
                if (_cells[x, y - 1] is Prey && _cells[x, y - 1] is not Predator && y > 0)
                {
                    KillPrey(_cells[x, y - 1], ref _cells[x, y]);
                    c.RestartTimeToFeed();
                    AddMovementsArray(ref movements, Movement.Down);
                }
        
                if (_cells[x + 1, y] is Prey && _cells[x + 1, y] is not Predator && x < Consts.OCEAN_NUM_COLS)
                {
                    KillPrey(_cells[x + 1, y], ref _cells[x, y]);
                    c.RestartTimeToFeed();
                    AddMovementsArray(ref movements, Movement.Right);
                }
        
                if (_cells[x - 1, y] is Prey && _cells[x - 1, y] is not Predator && x > 0)
                {
                    KillPrey(_cells[x - 1, y], ref _cells[x, y]);
                    c.RestartTimeToFeed();
                    AddMovementsArray(ref movements, Movement.Left);
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                return Movement.None;
            }
    
            if (movements.Length == 0)
            {
                return Movement.None;
            }
    
            if (movements.Length == 1)
            {
                return movements[0];
            }
    
            int index = BL.GetRandomInt(0, movements.Length - 1);
    
            return movements[index];
        }

        private Cell GetCellAt(Coordinates coord) => _cells[coord.X, coord.Y];

        private void AssignCellAt(Coordinates coord, ref Cell c)
        {
            int x = c.Coord.X;
            int y = c.Coord.Y;

            _cells[coord.X, coord.Y] = c;

            c.Coord.X = coord.X;
            c.Coord.Y = coord.Y;

            _cells[x, y] = null!;
        }

    #endregion

    private void KillPrey(Cell target, ref Cell killer)
    {
        if (target is Prey && target is not Predator)
        {
            ConfirmedKill(target.Coord.X, target.Coord.Y, target, ref killer);

            _cells[target.Coord.X, target.Coord.Y] = null!;
            _numPrey--;
        }
    }

    private void ConfirmedKill(int x, int y, Cell victim, ref Cell killer)
    {
        IShowKill predatorKill = (Predator)killer;

        predatorKill.KillPlace = new Coordinates(x, y);
        predatorKill.Killer = killer.DefaultImage;
        predatorKill.Victim = victim.DefaultImage;
        killer.SetSharkKill(true);

    }

    public void MoveAnimals()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int k = 0; k < _cells.GetLength(1); k++)
            {
                if (_cells[i, k] is Predator)
                {
                    Movement move = GetPreyNeighbor(ref _cells[i, k]);
        
                    if (move != Movement.None)
                    {
                        Coordinates tempCoord = GetCoordToMove(_cells[i, k], move);
                        AssignCellAt(tempCoord, ref _cells[i, k]);
                    }

                    continue;
                }
                
                if (_cells[i, k] is Prey)
                {
                    Movement  move = GetEmptyNeighbor(_cells[i, k]);
                    
                    if (move != Movement.None)
                    {
                        AssignCellAt(GetCoordToMove(_cells[i, k], move), ref _cells[i, k]);
                    }
                }
            }
        }
    }

    ~Ocean()
    {}
}
