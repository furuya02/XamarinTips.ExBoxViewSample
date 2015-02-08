using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExBoxViewSample {
    public class ExBoxView : BoxView {
        //public int Radius { get; set; } //角丸のサイズ
        public int ShadowSize { get; set; } //影の幅

        public static readonly BindableProperty RadiusProperty =
            BindableProperty.Create<ExBoxView, int>(p => p.Radius, 20);
        public int Radius {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public ExBoxView() {
            Radius = 10;
            ShadowSize = 5;
            WidthRequest = 150;
            HeightRequest = 150;
        }
    }
}

