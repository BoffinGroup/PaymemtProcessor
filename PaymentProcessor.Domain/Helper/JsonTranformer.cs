using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PaymentProcessor.Domain.Helper
{
    public static class JsonTranformer
    {
        public static string SerializeObject(object obj)
        {
            if (obj == null)
            {
                return "null";
            }
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }
    }
}
