using System;
using System.Collections.Generic;
using System.Text;

namespace Sakura.Extensions
{
    public static class DictionaryExtension
    {
        public static Value Get<Key, Value>(this Dictionary<Key, Value> dict, Key key)
        {
            if (dict == null || !dict.ContainsKey(key))
                return default(Value);
            return dict[key];
        }
    }
}
