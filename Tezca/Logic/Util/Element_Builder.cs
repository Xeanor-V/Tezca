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
using Android.Support.V7.Widget;
using static Android.Views.ViewGroup;

namespace Tezca.Logic.Util
{
    class Element_Builder
    {

        public Element_Builder()
        {

        }
        
        public CardView Build_Card(Context con)
        {
            CardView card = new CardView(con);
            //card.SetMinimumHeight(LayoutParams.WrapContent);
            //card.SetMinimumWidth(LayoutParams.MatchParent);
            //card.Elevation = 4.0f;
            CardView.LayoutParams LPar = new CardView.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            LPar.SetMargins(20, 20, 20, 20);
            card.LayoutParameters = LPar;
            card.Radius = 5.0F;
            TextView aux = new TextView(con);
            aux.Text = "HELLO MOFO";
            card.AddView(aux);
            return card;

            
        }
    }
}