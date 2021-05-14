﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex3.GarageLogic.Enums;

namespace Ex3.GarageLogic
{
    class Customer
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        public string OwnerName
        {
                get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
            set
            {
                m_OwnerPhone = value;
            }
        }
    }
}
