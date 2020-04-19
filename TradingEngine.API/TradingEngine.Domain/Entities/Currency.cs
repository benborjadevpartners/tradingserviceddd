using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        private readonly string _name;
        private readonly decimal _ratio;

        public Currency(string name, decimal ratio)
        {
            _name = name;
            _ratio = ratio;
        }

        public string GetName()
        {
            return _name;
        }

        public decimal GetRatio()
        {
            return _ratio;
        }

        public override string ToString()
        {
            return $"Currency:{{name={_name},ratio={_ratio}}}";
        }
    }
}
