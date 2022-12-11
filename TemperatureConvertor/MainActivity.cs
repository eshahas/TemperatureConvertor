using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;


namespace TemperatureConvertor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView txttemp;
        private Button btnCel, btnFar;
        double C, F;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnCel = FindViewById<Button>(Resource.Id.btncelcious);
            btnFar = FindViewById<Button>(Resource.Id.btnfarenheit);
            txttemp = FindViewById<TextView>(Resource.Id.txtTemp);

            btnCel.Click += btncelcious_Click;
            btnFar.Click  += btnfarenheit_Click;
        }


        private void btncelcious_Click(object sender, EventArgs e)
        {
            F = Convert.ToDouble(txttemp.Text);
            C = 5.0 / 9.0 * (F - 32);
            Toast.MakeText(context: this, text: "Result = " + C + "  ºC", duration: ToastLength.Long).Show();
        }


        private void btnfarenheit_Click(object sender, EventArgs e)
        {
            C = Convert.ToDouble(txttemp.Text);
            F = 9.0 / 5.0 * C + 32;
            Toast.MakeText(context: this, text: "Result = " + F + "  ºF", duration: ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}