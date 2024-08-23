namespace OceanLife;

public class Prey : Cell
{
    #region variables

        protected int _timeToReproduce;

    #endregion

    #region default ctor

        public Prey(int x, int y) : base(x, y, Image.Fish)
        {
            _timeToReproduce = Consts.DEFAULT_TIME_TO_REPRODUCE;   
        }

        public Prey(int x, int y, Image im) : base(x, y, im)
        {
            _timeToReproduce = Consts.DEFAULT_TIME_TO_REPRODUCE;  
        }

        public Prey(Coordinates coord) : this(coord.X, coord.Y)
        {}

        public Prey(Prey p) : base(p)
        {
            _timeToReproduce = p._timeToReproduce;
        }
        
    #endregion

    #region props

        public int TimeToReproduce
        {
            get
            {
                if (_timeToReproduce < 0)
                {
                    return 0;
                }

                return _timeToReproduce;
            }
            set
            {
                if (_timeToReproduce < 0)
                {
                    return;
                }

                _timeToReproduce = value;
            }
        }

    #endregion

    public override void ReduceTimeToReproduce()
    {
        if (_timeToReproduce == -1)
        {
            _timeToReproduce = 6;
        }

        _timeToReproduce -= 1;
    }

    public override int GetTimeToReproduce() => _timeToReproduce;

    ~Prey()
    {}
}
