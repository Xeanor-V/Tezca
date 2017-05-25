using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tezca.Logic.Util
{
    class Hash_Machine
    {

        public int getHash(string value)
        {
            int res = 0;
            int DictionaryPrime = 33;

            for (int index = 0; index < value.Length; index++)
                res += (res * DictionaryPrime) + value[index];
            return res;

        }
    }
}