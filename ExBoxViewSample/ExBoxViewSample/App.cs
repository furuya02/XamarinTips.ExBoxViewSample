using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExBoxViewSample {
    public class App : Application {
        public App() {

            var boxViewRed = new ExBoxView {
                Color = Color.Red
            };
            var boxViewBlue = new ExBoxView {
                Color = Color.Blue
            };

            var sliderRed = new Slider {
                Maximum = 100,
                WidthRequest = 200,
            };
            sliderRed.PropertyChanged += (s, a) => {
                boxViewRed.Radius = (int)sliderRed.Value;
            };

            var sliderBlue = new Slider {
                Maximum = 100,
                WidthRequest = 200,
            };
            sliderBlue.PropertyChanged += (s, a) => {
                boxViewBlue.Radius = (int)sliderBlue.Value;
            };

            var layout = new AbsoluteLayout();
            layout.Children.Add(boxViewRed, new Point(100, 100));
            layout.Children.Add(boxViewBlue, new Point(50, 50));

            layout.Children.Add(sliderRed, new Point(50, 300));
            layout.Children.Add(sliderBlue, new Point(50, 350));


            MainPage = new ContentPage {
                BackgroundColor = Color.White,
                Content = layout,
            };
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}

