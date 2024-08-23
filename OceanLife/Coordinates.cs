namespace OceanLife;

public class Coordinates
{
    #region variables

        private int _x;
        private int _y;

    #endregion

    #region default ctors

        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }
    
        public Coordinates() : this(0, 0)
        {}

        public Coordinates(Coordinates coord) : this(coord._x, coord._y)
        {}

    #endregion

    #region props
        
        public int X
        {
            get
            {
                if (_x < 0)
                {
                    return 0;
                }

                return _x;
            }
            set
            {
                if (_x < 0)
                {
                    return;
                }

                _x = value;
            }
        }

        public int Y
        {
            get
            {
                if (_y < 0)
                {
                    return 0;
                }

                return _y;
            }
            set
            {
                if (_y < 0)
                {
                    return;
                }

                _y = value;
            }
        }

    #endregion

    ~Coordinates()
    {}
}
