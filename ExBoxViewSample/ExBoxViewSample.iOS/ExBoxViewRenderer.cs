using System;
using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using ExBoxViewSample;
using ExBoxViewSample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExBoxView), typeof(ExBoxViewRenderer))]
namespace ExBoxViewSample.iOS {
    internal class ExBoxViewRenderer : BoxRenderer {

        public override void Draw(CGRect rect) {
            //base.Draw(rect); // <-- デフォルトの描画を無効にする

            var exBoxView = (ExBoxView) Element; // <-- Xamarin.Forms側のオブジェクトを取得
            using (var context = UIGraphics.GetCurrentContext()) {

                var shadowSize = exBoxView.ShadowSize;
                var blur = shadowSize; //　<-- ほやけ具合は影のサイズと同じにする
                var radius = exBoxView.Radius;

                context.SetFillColor(exBoxView.Color.ToCGColor()); // <--  Xamarin.Forms側のオブジェクトのプロパティから塗りつぶしの色を指定
                var bounds = Bounds.Inset(shadowSize*2, shadowSize*2); // <-- 影の分だけ小さいサイズを計算する
                context.AddPath(CGPath.FromRoundedRect(bounds, radius, radius));
                // <-- 角丸についてはXamarin.Forms側のオブジェクトのプロパティから取得している
                context.SetShadow(new SizeF(shadowSize, shadowSize), blur); // <-- iOSのAPIであるSetShadowを使用して影を描画している
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Radius") {
                SetNeedsDisplay(); //再描画
            }
        }


    }
}