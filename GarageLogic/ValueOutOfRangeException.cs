using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private const string m_OutOfRangeExceptionMessage = "Value must be between {0} to {1}";
        private float MaxValue
        {
            get
            {
                return this.m_MaxValue;
            }
            set
            {
                this.m_MaxValue = value;
            }
        }
        private float MinValue
        {
            get
            {
                return this.m_MinValue;
            }
            set
            {
                this.m_MinValue = value;
            }
        }

        public ValueOutOfRangeException(float i_MinRangeValue, float i_MaxRangeValue) : base(string.Format(m_OutOfRangeExceptionMessage, i_MinRangeValue, i_MaxRangeValue))
        {
            MinValue = i_MinRangeValue;
            MaxValue = i_MaxRangeValue;  
        }
    }
}
