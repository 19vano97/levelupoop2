using System.Security.Cryptography.X509Certificates;

namespace OceanLife;

public class Predator : Prey, IShowKill
{
    #region varaibles

        protected int _timeToFeed;
        protected bool _doesShartkillInIteration;

    #endregion

    #region default ctors

        public Predator(int x, int y) : base(x, y, Image.Shark)
        {
            _timeToFeed = Consts.DEFAULT_TIME_TO_FEED;
        }

        public Predator(Coordinates coord) : this(coord.X, coord.Y)
        {}

        public Predator(Predator p) : base(p)
        {
            _timeToFeed = p._timeToFeed;
        }

    #endregion

    #region prop

        public int TimeToFeed
        {
            get
            {
                if (_timeToFeed < 0)
                {
                    return 0;
                }

                return _timeToFeed;
            }
            set
            {
                if (_timeToFeed < 0)
                {
                    return;
                }
                
                _timeToFeed = value;
            }
        }

    #endregion

    #region IShowKill

        public Coordinates KillPlace {get; set;}
        public Image Victim {get; set;}
        public Image Killer {get; set;}
        
    #endregion

    public override void ReduceTimeToFeed() => _timeToFeed -= 1;

    public override int GetTimeToFeed() => _timeToFeed;

    public override void RestartTimeToFeed()
    {
        _timeToFeed = Consts.DEFAULT_TIME_TO_FEED;
    }

    public override bool DoesShartkillInIteration() => _doesShartkillInIteration;

    public override void SetSharkKill(bool killed) => _doesShartkillInIteration = killed;

    ~Predator()
    {}
}
