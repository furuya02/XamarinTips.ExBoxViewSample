using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExBoxViewSample;
using ExBoxViewSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExBoxView), typeof(ExBoxViewRenderer))]

namespace ExBoxViewSample.Droid {
    internal class ExBoxViewRenderer : BoxRenderer {

        public override void Draw(Canvas canvas) {
            //base.Draw(canvas); <-- �f�t�H���g�̕`��𖳌��ɂ���

            var exBoxView = (ExBoxView) Element; // <-- Xamarin.Forms���̃I�u�W�F�N�g���擾

            using (var paint = new Paint()) {

                var shadowSize = exBoxView.ShadowSize;
                var blur = shadowSize;
                var radius = exBoxView.Radius;

                paint.AntiAlias = true; // <-- �A���`�G�C���A�X�L��

                //�e�̕`��
                paint.Color = (Xamarin.Forms.Color.FromRgba(0, 0, 0, 112)).ToAndroid();
                paint.SetMaskFilter(new BlurMaskFilter(blur, BlurMaskFilter.Blur.Normal));
                var rectangle = new RectF(shadowSize, shadowSize, Width - shadowSize, Height - shadowSize);
                canvas.DrawRoundRect(rectangle, radius, radius, paint);

                //�{�̂̕`��
                paint.Color = exBoxView.Color.ToAndroid();
                paint.SetMaskFilter(null);
                rectangle = new RectF(0, 0, Width - shadowSize*2, Height - shadowSize*2);
                canvas.DrawRoundRect(rectangle, radius, radius, paint);
            }

        }

        //2015.02.09�ǉ�
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Radius"){
                Invalidate(); //�ĕ`��
            }
        }
    }
}
