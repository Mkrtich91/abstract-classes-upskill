using System;

namespace TollCalculator
{
    /// <summary>
    /// Represents a taxi class.
    /// </summary>
    public class Taxi : Vehicle
    {
        private int passengers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Taxi"/> class with the specified <paramref name="baseToll"/> and <paramref name="passengers"/>.
        /// </summary>
        /// <param name="baseToll">A baseToll of this <see cref="Taxi"/> class.</param>
        /// <param name="passengers">A passengers of this <see cref="Taxi"/> class.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="baseToll"/>less than zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="passengers"/>less than zero.</exception>
        public Taxi(decimal baseToll, int passengers)
            : base(baseToll)
        {
            if (passengers < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(passengers), "Number of passengers cannot be less than zero.");
            }

            this.passengers = passengers;
        }

        /// <summary>
        /// Gets or sets a passengers.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>less than zero.</exception>
        public int Passengers
        {
            get => this.passengers;
            set
            {
                if (value < 0)
                {
                throw new ArgumentOutOfRangeException(nameof(value), "Number of passengers cannot be less than zero.");
                }

                this.passengers = value;
            }
        }

        /// <summary>
        /// Calculates the base toll that relies only on the car type.
        /// ----------------------------------------------
        /// Passengers count        Extra or discount
        /// ----------------------------------------------
        /// 0                       extra $0.50
        /// 2                       $0.50 discount
        /// 3 and more              $1.00 discount.
        /// </summary>
        /// <returns>The base toll of car.</returns>
        protected override decimal Calculate()
        {
            if (this.passengers == 0)
            {
                return this.BaseToll + 0.50m;
            }
            else if (this.passengers == 2)
            {
                return this.BaseToll - 0.50m;
            }
            else if (this.Passengers >= 3)
            {
                return this.BaseToll - 1.00m;
            }
            else
            {
                return this.BaseToll;
            }
        }
    }
}
