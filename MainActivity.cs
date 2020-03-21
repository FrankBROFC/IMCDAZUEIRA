using System;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace IMCDAZUEIRA
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText edPeso;
        EditText edAltura;
        Button btnCalculo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            edAltura = FindViewById<EditText>(Resource.Id.edAltura);
            edPeso = FindViewById<EditText>(Resource.Id.edPeso);

            btnCalculo = FindViewById<Button>(Resource.Id.btnCalculo);
            btnCalculo.Click += BtnCalculo_Click;

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }

        private void BtnCalculo_Click(object sender, EventArgs e)
        {
            if (edAltura.Text == "" || edPeso.Text == "")
            {
                using Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = builder.Create();

                alert.SetTitle("Campos vazios!!!");
                alert.SetIcon(Resource.Drawable.notification_bg_normal);
                alert.SetMessage("O campo peso e/ou alerta estão vazios!");

                alert.SetButton("OK", (s, ev) =>
                {
                    Toast.MakeText(this, "Legal, vamos continuar... !", ToastLength.Short).Show();
                });
                alert.Show();
            }
            else
            {
                var resultado = 0.0;

                if (edPeso.Text.Contains('.'))
                {
                    var altura = Convert.ToDouble(edAltura.Text);
                    var peso = Convert.ToDouble(edPeso.Text);
                    resultado = (peso / (altura * altura)) * 1000;
                }
                else
                {
                    var altura = Convert.ToDouble(edAltura.Text);
                    var peso = Convert.ToDouble(edPeso.Text);
                    resultado = (peso / (altura * altura)) * 10000;
                }

                Intent intentEnviadora = new Intent(this, typeof(Resultado));
                Bundle paramentos = new Bundle();

                paramentos.PutDouble("resultado", resultado);
                intentEnviadora.PutExtras(paramentos);

                StartActivity(intentEnviadora);
            }
        }
    }
}

