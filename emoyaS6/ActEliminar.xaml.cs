using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace emoyaS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActEliminar : ContentPage
    {
        private string Url = "http://172.29.192.1/Prueba/post.php";
        public ActEliminar(estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text= datos.codigo.ToString();   
            txtNombre.Text= datos.nombre.ToString();
            txtApellido.Text= datos.apellido.ToString();
            txtEdad.Text=datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {
                datos.Add("codigo", txtCodigo.Text);
                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);

                cliente.UploadValues(Url + "?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", datos);
              
                Navigation.PushAsync(new MainPage());
               

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
                
            }
             


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var datos = new System.Collections.Specialized.NameValueCollection();
            try
            {

                datos.Add("codigo", txtCodigo.Text);
                cliente.UploadValues(Url + "?codigo=" + txtCodigo.Text, "DELETE", datos);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");

            }
        }
    }
}