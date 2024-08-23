namespace OceanLife;

public abstract class Cell
{
    #region variables

        protected Coordinates _coord;
        protected Image _defaultImage; 

    #endregion

    #region default ctors

        public Cell(int x, int y)
        {
            _coord = new Coordinates(x, y);
            _defaultImage = Image.Cell;
        }

        public Cell(int x, int y, Image im)
        {
            _coord = new Coordinates(x, y);
            _defaultImage = im;
        }

        public Cell(Coordinates coord) : this(coord.X, coord.Y)
        {}

        public Cell(Cell c) : this(c._coord.X, c._coord.Y, c._defaultImage)
        {}

    #endregion

    #region prop

        public Coordinates Coord
        {
            get
            {
                return _coord;
            }
            set
            {
                _coord = value;
            }
        }

        public Image DefaultImage
        {
            get
            {
                return _defaultImage;
            }
        }

    #endregion

    public virtual void ReduceTimeToReproduce()
    {}

    public virtual void ReduceTimeToFeed()
    {}

    public virtual int GetTimeToReproduce() => 0;

    public virtual int GetTimeToFeed() => 0;

    public virtual void RestartTimeToFeed()
    {}

    public virtual bool DoesShartkillInIteration() => false;

    public virtual void SetSharkKill(bool killed)
    {}

    ~Cell()
    {}

}
