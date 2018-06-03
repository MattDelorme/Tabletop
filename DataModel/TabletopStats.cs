using System;

namespace Tabletop
{
    [Serializable]
    public struct TabletopStats
    {
        public int Movement;

        public int WS;
        public int BS;
        public int S;
        public int T;
        public int W;
        public int I;
        public int A;
        public int Ld;

        public static TabletopStats operator +(TabletopStats a, TabletopStats b)
        {
            TabletopStats result = new TabletopStats();

            result.Movement = a.Movement + b.Movement;

            result.WS = a.WS + b.WS;
            result.BS = a.BS + b.BS;
            result.S = a.S + b.S;
            result.T = a.T + b.T;
            result.W = a.W + b.W;
            result.I = a.I + b.I;
            result.A = a.A + b.A;
            result.Ld = a.Ld + b.Ld;
            return result;
        }

        public static TabletopStats operator -(TabletopStats a, TabletopStats b)
        {
            TabletopStats result = new TabletopStats();

            result.Movement = a.Movement - b.Movement;

            result.WS = a.WS - b.WS;
            result.BS = a.BS - b.BS;
            result.S = a.S - b.S;
            result.T = a.T - b.T;
            result.W = a.W - b.W;
            result.I = a.I - b.I;
            result.A = a.A - b.A;
            result.Ld = a.Ld - b.Ld;
            return result;
        }

        public int GetBaseBSRoll()
        {
            var baseBSRoll = 7 - BS;
            return baseBSRoll > 1 ? baseBSRoll : 2;
        }

        public int GetWoundRoll(int strength)
        {
            int woundRoll = 4 + T - strength;

            if (woundRoll < 2)
            {
                woundRoll = 2;
            }
            else if (woundRoll == 7)
            {
                woundRoll = 6;
            }
            return woundRoll;
        }
    }
}
