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
using Android.Graphics;
using Android.Util;
using Android.Text;

namespace Tezca.Logic.Util
{
    class Element_Builder
    {
        private Context con;
        private int idBegin;
        public Element_Builder(Context con, int idBegin)
        {
            this.con = con;
            this.idBegin = idBegin;
        }
        
        public CardView Build_Card(string text)
        {
            CardView card = new CardView(con);
            //card.SetMinimumHeight(LayoutParams.WrapContent);
            //card.SetMinimumWidth(LayoutParams.MatchParent);
            //card.Elevation = 4.0f;
            CardView.LayoutParams LPar = new CardView.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            LPar.SetMargins(getDp(20), getDp(20), getDp(20), getDp(20));
            card.LayoutParameters = LPar;
            card.Radius = 5.0F;
            card.AddView(Build_Textview(text));

            Button button = new Button(con);
            LinearLayout.LayoutParams LBut = new LinearLayout.LayoutParams(getDp(110), getDp(40));
            LBut.SetMargins(getDp(20), getDp(20), getDp(20), getDp(20));
            button.SetTextSize(ComplexUnitType.Sp, 20);
            button.Text = "Details";
            button.SetBackgroundResource(Resource.Drawable.Normal_Button);
            card.AddView(button);
            return card;
        }


        public LinearLayout Build_Char()
        {

            LinearLayout LL = new LinearLayout(con);

            LL.Orientation = Orientation.Vertical;
            LL.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);



            EditText ename = Build_EditText(32, 300, 40);
            ename.Id = idBegin;
            idBegin++;


            EditText edesc = Build_EditText(250, 300, 100);
            edesc.Id = idBegin;
            idBegin++;


            LL.AddView(Build_divider());
            LL.AddView(Build_Textview("Name"));
            LL.AddView(ename);
            LL.AddView(Build_Textview( "Description"));
            LL.AddView(edesc);
            return LL;
        }

        public LinearLayout Build_CharTop()
        {

            LinearLayout LL = new LinearLayout(con);

            LL.Orientation = Orientation.Vertical;
            LL.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);



            EditText ename = Build_EditText(32, 300, 40);
            ename.Id = idBegin;
            idBegin++;


            EditText edesc = Build_EditText(250, 300, 100);
            edesc.Id = idBegin;
            idBegin++;
            LL.AddView(Build_Textview("Name"));
            LL.AddView(ename);
            LL.AddView(Build_Textview("Description"));
            LL.AddView(edesc);
            return LL;
        }

        public EditText Build_EditText( int size,int width, int height)
        {
           
            EditText text = new EditText(con);
            LinearLayout.LayoutParams Lsd = new LinearLayout.LayoutParams(getDp(width), getDp(height));
            text.InputType = InputTypes.TextFlagNoSuggestions;
            Lsd.SetMargins(getDp(20) ,getDp(20), getDp(20), getDp(20));
            text.SetBackgroundResource(Resource.Drawable.Normal_EditText);
            text.LayoutParameters = Lsd;
           text.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(size) });
            text.SetTextColor(Color.ParseColor("#ffffa726"));
            return text;
            

        }

        public int getDp(int size)
        {
            var dp = size;
            int pixel = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, con.Resources.DisplayMetrics);
            return pixel;
        }

        public View Build_divider()
        {
            View divider = new View(con);
            LinearLayout.LayoutParams Lsd = new LinearLayout.LayoutParams(getDp(100),getDp( 3));
            Lsd.SetMargins(getDp(20), getDp(20), getDp(20), getDp(20));
            divider.LayoutParameters = Lsd;
            divider.SetBackgroundColor(Color.ParseColor("#FFE0B2"));

            return divider;

        }

        public TextView Build_Textview(string text)
        {
            TextView TVname = new TextView(con);
            TVname.Text = text;
            TVname.SetTextColor(Color.ParseColor("#FFF3E0"));
            TVname.SetTextSize(ComplexUnitType.Sp, 20);
            LinearLayout.LayoutParams Lsd = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            Lsd.SetMargins(getDp(20), 0, 0, 0);
            TVname.LayoutParameters = Lsd;


            return TVname;
        }
    }
}