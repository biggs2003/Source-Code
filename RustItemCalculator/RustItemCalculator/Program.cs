using System;
/// <summary>
/// Generates a count for making timed explosive in Rust (The game)
/// </summary>
namespace RustItemCalculator
{
    /// <summary>
    /// Wrapper to run the program. Change the 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RustItem test = new RustItem();
            ///
            /// Change this value to adjust the calculation.
            /// 
            int amountToMake = 4;
            test.TimedExplosive += amountToMake;
            foreach (System.Reflection.PropertyInfo p in test.GetType().GetProperties())
            {
                if (p.CanRead)
                {
                    Console.WriteLine("{0}: {1}", p.Name, p.GetValue(test, null));
                }
            }
            Console.WriteLine("Done!");
        }
    }
    /// <summary>
    /// Generic description for items in Rust
    /// </summary>
    public class RustItem
    {
        private int _TimeSpent;

        /// <summary>
        /// Amount of time spent to craft the items needed.
        /// </summary>
        /// <value>
        /// The time spent in seconds.
        /// </value>
        public int TimeSpent
        {
            get { return _TimeSpent; }
            set { _TimeSpent = value; }
        }

        #region SourceMaterials
        private int _Fat;
        /// <summary>
        /// The amount of fat needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of fat.
        /// </value>
        public int Fat
        {
            get { return _Fat; }
            set { _Fat = value; }
        }

        private int _Cloth;
        /// <summary>
        /// The amount of cloth needed to craft items.
        /// </summary>
        /// <value>
        /// The the amount of cloth.
        /// </value>
        public int Cloth
        {
            get { return _Cloth; }
            set { _Cloth = value; }
        }

        private int _Sulfur;
        /// <summary>
        /// The amount of sulfur needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of sulfur.
        /// </value>
        public int Sulfur
        {
            get { return _Sulfur; }
            set { _Sulfur = value; }
        }

        private int _MetalFragments;
        /// <summary>
        /// The amount of metal fragments needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of metal fragments.
        /// </value>
        public int MetalFragments
        {
            get { return _MetalFragments; }
            set { _MetalFragments = value; }
        }

        private int _Charcoal;
        /// <summary>
        /// The amount of charcoal needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of charcoal.
        /// </value>
        public int Charcoal
        {
            get { return _Charcoal; }
            set { _Charcoal = value; }
        }

        #endregion

        #region CraftedMaterials
        private int _LowGradeFuel;
        /// <summary>
        /// The amount of low grade fuel needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of low grade fuel.
        /// </value>
        public int LowGradeFuel
        {
            get { return _LowGradeFuel; }
            set
            {
                Fat += (3 * (_LowGradeFuel + value));
                Cloth += (1 * (_LowGradeFuel + value));
                TimeSpent += (5 * (_LowGradeFuel + value));
                _LowGradeFuel = value * 3;
            }
        }

        private int _GunPowder;
        /// <summary>
        /// The amount of gun poweder needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of gun powder.
        /// </value>
        public int GunPowder
        {
            get { return _GunPowder; }
            set
            {
                Charcoal += (30 * (_GunPowder + value));
                Sulfur += (20 * (_GunPowder + value));
                TimeSpent += (10 * (_GunPowder + value));
                _GunPowder = value * 10;
            }
        }
        private int _Explosives;
        /// <summary>
        /// The amount of explosives needed to craft items.
        /// </summary>
        /// <value>
        /// The amount of explosives.
        /// </value>
        public int Explosives
        {
            get { return _Explosives; }
            set
            {
                GunPowder += (50 / 10 * (_Explosives + value));
                LowGradeFuel += (3 / 3 * (_Explosives + value));
                Sulfur += (10 * (_Explosives + value));
                MetalFragments += (10 * (_Explosives + value));
                TimeSpent += (10 * (_Explosives + value));
                _Explosives = value;
            }
        }

        private int _TimedExplosive;
        /// <summary>
        /// The amount of timed explosives to be generated.
        /// </summary>
        /// <value>
        /// The amount of timed explosive.
        /// </value>
        public int TimedExplosive
        {
            get { return _TimedExplosive; }
            set
            {
                Explosives += (25 * (_TimedExplosive + value));
                Cloth += (5 * (_TimedExplosive + value));
                TimeSpent += (30 * (_TimedExplosive + value));
                _TimedExplosive = value;
            }
        }

        #endregion
    }
}
