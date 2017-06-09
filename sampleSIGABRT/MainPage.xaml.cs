#region [Imports]
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace sampleSIGABRT {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        #region[dataManagement]
        async Task chargeLists() {
            try {
                scroll.IsVisible = false; //Breakpoint goes here
				overlay.IsVisible = true;
                await Task.Run(() => {
                    try {
                        string message = "Something async goes here\nBut you aren't allowed to see it";
                        Debug.WriteLine (string.Format ("Hello_world! {0}", message));
                        int i = 0;
                        while (i <= 500) {
                            i++;
                            Debug.WriteLine (string.Format ("{0}", i));
                        }
                    } catch (Exception ex) {
                        Debug.WriteLine(string.Format("Error {0}", ex.Message));
                    }
                });
                overlay.IsVisible = false;
                scroll.IsVisible = true;
            } catch (Exception ex) {
                Debug.WriteLine(string.Format("Error {0}", ex.Message));
            }
        }
        #endregion

        #region[events]
#pragma warning disable RECS0165
        protected override async void OnAppearing() {
            await chargeLists();
            base.OnAppearing();
        }

        protected override async void OnDisappearing() {
            await chargeLists();
            base.OnDisappearing();
        }
#pragma warning restore RECS0165
        #endregion
    }
}