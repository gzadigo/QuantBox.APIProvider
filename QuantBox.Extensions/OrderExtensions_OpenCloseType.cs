﻿using XAPI;
using SmartQuant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Extensions
{
    public static class OrderExtensions_OpenCloseType
    {
        public static int index = OrderTagType.Network;

        public static Order Open(this Order order)
        {
            order.SetOpenClose(OpenCloseType.Open);
            return order;
        }

        public static Order Close(this Order order)
        {
            order.SetOpenClose(OpenCloseType.Close);
            return order;
        }

        public static Order CloseToday(this Order order)
        {
            order.SetOpenClose(OpenCloseType.CloseToday);
            return order;
        }

        public static Order SetOpenClose(this Order order, OpenCloseType OpenClose)
        {
            order.GetDictionary(index)[OrderTagType.PositionEffect] = (byte)OpenClose;
            return order;
        }

        public static OpenCloseType? GetOpenClose(this Order order)
        {
            object obj = order.GetDictionaryValue(OrderTagType.PositionEffect, index);
            if(obj == null)
            {
                return (OpenCloseType?)obj;
            }
            return (OpenCloseType?)(byte)obj;
        }
    } 
}
