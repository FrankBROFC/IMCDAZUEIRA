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

namespace IMCDAZUEIRA
{
    class imc
    {
        public double altura { get; set; }
        public double peso { get; set; }

        public double Resultado(double altura, double peso)
        {
            return (altura * 2) / peso;
        }
    }
}