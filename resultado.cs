using System;
using System.Collections.Generic;
using System.Globalization;
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
    [Activity(Label = "resultado")]
    public class Resultado : Activity
    {
        TextView txtResultado;
        TextView txtFraseMotivadora;
        ImageView imgMeme;
        readonly Random escolha_imagem_rd = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.resultado);

            var escolha_imagem = escolha_imagem_rd.Next(1, 3);

            txtResultado = FindViewById<TextView>(Resource.Id.txtResultado);
            txtFraseMotivadora = FindViewById<TextView>(Resource.Id.txtFraseMotivadora);
            imgMeme = FindViewById<ImageView>(Resource.Id.imgMeme);

            var resultado = Intent.Extras.GetDouble("resultado");
            var resultadoFormatado = Convert.ToDouble(resultado.ToString("#.#"));

            //Abaixo do peso
            if (resultadoFormatado <= 18.5)
            {
                txtResultado.Text = resultadoFormatado + " ABAIXO DO PESO.";

                imgMeme.SetImageResource(Resource.Drawable.meme_abaixo_peso_01);
            }
            //Peso Ideal
            else if (resultadoFormatado <= 24.9)
            {
                txtResultado.Text = resultadoFormatado + " SAÚDAVEL.";

                txtFraseMotivadora.SetText(Resource.String.frase_peso_ideal_01);
                if (escolha_imagem == 1) imgMeme.SetImageResource(Resource.Drawable.meme_peso_ideal_01);

                else imgMeme.SetImageResource(Resource.Drawable.meme_peso_ideal_02);
            }
            //Peso acima do peso
            else if (resultadoFormatado <= 29.9)
            {
                txtResultado.Text = resultadoFormatado + " ACIMA DO PESO";

                imgMeme.SetImageResource(Resource.Drawable.meme_acima_peso_01);

                txtFraseMotivadora.SetText(Resource.String.frase_emagracimento_01);
            }
            //Obesidade I
            else if (resultadoFormatado <= 34.9)
            {
                txtResultado.Text = resultadoFormatado + " OBESO 1";

                imgMeme.SetImageResource(Resource.Drawable.meme_obesidadeI_01);

                txtFraseMotivadora.SetText(Resource.String.frase_emagrecimento_02);
            }
            //Obesidade II
            else if (resultadoFormatado <= 39.9)
            {
                txtResultado.Text = resultadoFormatado + " OBESO 2 (SEVERA)";

                txtFraseMotivadora.SetText(Resource.String.frase_emagrecimento_03);

                if (escolha_imagem == 1) imgMeme.SetImageResource(Resource.Drawable.meme_obesidadeII_01);

                else imgMeme.SetImageResource(Resource.Drawable.meme_obesidadeII_02);
            }
            //Obesidade III
            else
            {
                txtResultado.Text = resultadoFormatado + " OBESO 3 (MÓRBIDA)";

                txtFraseMotivadora.SetText(Resource.String.frase_emagrecimento_04);

                imgMeme.SetImageResource(Resource.Drawable.meme_obesidadeIII_01);
            }
        }
    }
}