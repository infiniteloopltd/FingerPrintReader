using Windows.Security.Credentials;

namespace FingerPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var supported = await KeyCredentialManager.IsSupportedAsync();
            if (!supported) return;
            var result =
                await KeyCredentialManager.RequestCreateAsync("login",
                    KeyCredentialCreationOption.ReplaceExisting);
            if (result.Status == KeyCredentialStatus.Success)
            {
                MessageBox.Show("Logged in.");
            }
            else
            {
                MessageBox.Show("Login failed.");
            }
        }
    }
}