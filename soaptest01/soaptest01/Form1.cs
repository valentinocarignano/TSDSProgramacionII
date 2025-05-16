using ServiceReference1;

namespace soaptest01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.CountryInfoServiceSoapTypeClient client = new ServiceReference1.CountryInfoServiceSoapTypeClient(ServiceReference1.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

            tCountryCodeAndName[] listaCodigosNombres = client.ListOfCountryNamesByCode();
            tCountryCodeAndName arg = listaCodigosNombres[10];
            string respFLag = client.CountryFlag(arg.sISOCode);

            MessageBox.Show(respFLag);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
