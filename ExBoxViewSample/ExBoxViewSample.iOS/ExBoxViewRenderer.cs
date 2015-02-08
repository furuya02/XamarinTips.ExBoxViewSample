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
            //base.Draw(rect); // <-- �f�t�H���g�̕`��𖳌��ɂ���

            var exBoxView = (ExBoxView) Element; // <-- Xamarin.Forms���̃I�u�W�F�N�g���擾
            using (var context = UIGraphics.GetCurrentContext()) {

                var shadowSize = exBoxView.ShadowSize;
                var blur = shadowSize; //�@<-- �ق₯��͉e�̃T�C�Y�Ɠ����ɂ���
                var radius = exBoxView.Radius;

                context.SetFillColor(exBoxView.Color.ToCGColor()); // <--  Xamarin.Forms���̃I�u�W�F�N�g�̃v���p�e�B����h��Ԃ��̐F���w��
                var bounds = Bounds.Inset(shadowSize*2, shadowSize*2); // <-- �e�̕������������T�C�Y���v�Z����
                context.AddPath(CGPath.FromRoundedRect(bounds, radius, radius));
                // <-- �p�ۂɂ��Ă�Xamarin.Forms���̃I�u�W�F�N�g�̃v���p�e�B����擾���Ă���
                context.SetShadow(new SizeF(shadowSize, shadowSize), blur); // <-- iOS��API�ł���SetShadow���g�p���ĉe��`�悵�Ă���
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Radius") {
                SetNeedsDisplay(); //�ĕ`��
            }
        }


    }
}