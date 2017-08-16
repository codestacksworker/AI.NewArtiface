using System;
using Apache.NMS;

namespace SING.Service.ActiveMQ
{
    public class MqHelper
    {
        //设置Message的Body信息
        public static void SetMapMessage<T>(IMapMessage mapMessage, T messages)
        {
            if (mapMessage == null || object.Equals(messages, null))
            {
                return;
            }

            foreach (var propertyInfo in messages.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType.Name == "String")
                    mapMessage.Body.SetString(propertyInfo.Name, Convert.ToString(propertyInfo.GetValue(messages, null)));
                else
                    mapMessage.Body.SetInt(propertyInfo.Name, Convert.ToInt16(propertyInfo.GetValue(messages, null)));
            }
        }

        public static T GetMapMessageByIMapMessage<T>(IMapMessage mapMessage) where T : class, new()
        {
            if (mapMessage == null)
            {
                return default(T);
            }

            var MapMessage = new T();
            foreach (var propertyInfo in MapMessage.GetType().GetProperties())
            {
                propertyInfo.SetValue(MapMessage, mapMessage.Body[propertyInfo.Name], null);
            }

            return MapMessage;
        }

        public static T GetMapMessageByIMapMessage<T>(IMapMessage mapMessage, T MapMessage) where T : class, new()
        {
            if (mapMessage == null || object.Equals(MapMessage, null))
            {
                return default(T);
            }
            
            foreach (var propertyInfo in MapMessage.GetType().GetProperties())
            {
                propertyInfo.SetValue(MapMessage, mapMessage.Body[propertyInfo.Name.ToUpper()], null);
            }

            return MapMessage;
        }
    }
}
