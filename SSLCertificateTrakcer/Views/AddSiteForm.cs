namespace SSLCertificateTracker
{
    public partial class AddSiteForm : Form
    {

        public string Userinput { get; private set; } = string.Empty;

        public AddSiteForm()
        {
            InitializeComponent();
        }


        public void AddSiteConfirmClick(object? sender, EventArgs e)
        {
            //Ensures an empty string or white space is not passed to the controller
            if (string.IsNullOrWhiteSpace(WebAddressInput.Text))
            {
                CharacterErrorLbl.Text = "Empty line or spaces are not valid.";
                return;
            }

            Userinput = WebAddressInput.Text;
            CharacterErrorLbl.Text = string.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Form2_Click(object sender, EventArgs e)
        {
            CharacterErrorLbl.Text = string.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
