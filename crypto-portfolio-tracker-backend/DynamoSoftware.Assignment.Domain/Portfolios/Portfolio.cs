using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoSoftware.Assignment.Domain.Portfolios
{
    internal sealed class Portfolio : IPortfolio
	{
        public Portfolio(IEnumerable<IPortfolioItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.Items = items;
        }

        public IEnumerable<IPortfolioItem> Items { get; }

        public double InitialValue
        {
            get
            {
                return this.Items.Sum(x => x.InitialValue);
            }
        }

        public double CurrentValue
        {
            get
            {
                return this.Items.Sum(x => x.CurrentValue);
            }
        }

        public double OverallChangeValue
        {
            get
            {
                return this.CurrentValue - this.InitialValue;
            }
        }

        public double OverallChangePercentage
        {
            get
            {
                if (this.InitialValue == 0)
                {
                    return 0;
                }

                var changePercentage = this.OverallChangeValue / this.InitialValue * 100;
                return Math.Round(changePercentage, PortfolioConstants.PercentagePrecision);
            }
        }
    }
}