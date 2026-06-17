namespace SSLCertificateTracker
{
    public partial class AddSiteForm : Form
    {
        public event Action<string>? OnUserInputConfirm;

        public AddSiteForm()
        {
            InitializeComponent();
        }


        public async void AddSiteConfirmClick(object? sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(WebAddressInput.Text))
            {
                CharacterErrorLbl.Text = "Empty line or spaces are not valid.";
                return;
            }

            OnUserInputConfirm?.Invoke(WebAddressInput.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Form2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
