using System;
using System.Collections.Generic;
using System.Text;

namespace SSLCertificateTracker
{
    internal class CommentedCode
    {

        //public void LoadCertificate(List<DataGrid> dataGridList)
        //{

        //    //_dataGridList.Add(dataGridList);

        //    //bs!.ResetBindings(false);

        //    //UpdateRowcount();
        //}


        //private async void rfshSelectedBtn_Click(object sender, EventArgs e)
        //{
        //    //var Website = sslDataGrid.SelectedRows[0].Cells["websiteAddressDesign"].Value.ToString();

        //    //certificateResult = await certificateService.WebConnectAsync(Website, port);

        //    ////call to LoadCertificate Method
        //    //UpdateCertificate(certificateResult, Website);

        //}

        //public void UpdateCertificate(X509Certificate2 cert, string website)
        //{

        //    //var data = new CertificateView(cert, website);

        //    //var options = new JsonSerializerOptions { WriteIndented = true };

        //    //var json = JsonSerializer.Serialize(data, options);

        //    //Debug.WriteLine(json);

        //    //CertificateList.

        //    //bs.ResetBindings(false);
        //}

        //private async void AddNewSiteAsync()
        //{
        //    using AddSiteForm addSiteForm = new AddSiteForm();
        //    if (addSiteForm.ShowDialog(this) != DialogResult.OK)
        //    {
        //        return;
        //    }
        //    try
        //    {


        //        bool alreadytracked = false;

        //        //loops through each and returns already tracked as true if userinput matches what was a website that is already added to the sslDataGridView
        //        for (int i = 0; i < sslDataGrid.RowCount; i++)
        //        {

        //            if (string.Equals(sslDataGrid.Rows[i].Cells["WebsiteColumn"].Value!.ToString(), addSiteForm.FinalUri.Host, StringComparison.OrdinalIgnoreCase))
        //            {
        //                alreadytracked = true;
        //                break;
        //            }
        //        }

        //        if (alreadytracked)
        //        {

        //            var response = MessageBox.Show($"{addSiteForm.FinalUri.Host} is already being tracked.\n\nWould you like enter a new site?", "Already Tracked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //            if (response == DialogResult.Yes)
        //            {
        //                AddNewSiteAsync();
        //            }
        //        }
        //        else
        //        {
        //            //Returns X509Certificart2 and Stores a copy after the TcpClient and SslStream are closed.
        //            certificateResult = await certificateService.WebConnectAsync(addSiteForm.FinalUri.Host, port);

        //            LoadCertificate(certificateResult, addSiteForm.FinalUri.Host);
        //        }
        //    }
        //    catch (SocketException ex)
        //    {
        //        MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //public async void InitializeDataAsync()
        //{
        //    //string expandedFolderpath = Environment.ExpandEnvironmentVariables(FolderPath);
        //    //string Filepath = Environment.ExpandEnvironmentVariables(Path.Combine(FolderPath, "sites.json"));


        //    //JsonSerializerOptions options = new () { PropertyNameCaseInsensitive = true, IncludeFields = true };

        //    //if (!Directory.Exists(expandedFolderpath))
        //    //{
        //    //    Directory.CreateDirectory(expandedFolderpath);
        //    //    Debug.WriteLine($"Application folder not found in directory.\nNew Folder Path created for application data:\nFile Path: {expandedFolderpath}");
        //    //}

        //    ////Binding Data to the Grid before form is created.
        //    //if (File.Exists(Filepath))
        //    //{
        //    //    using Stream ExistingJson =  File.OpenRead(Filepath);
        //    //    _dataGridList = await JsonSerializer.DeserializeAsync<List<CertificateModel>>(ExistingJson, options);
        //    //        Debug.WriteLine($"Certificate Data Parsed From JSON.\nFile Path: {Filepath}");

        //    //}
        //    //else
        //    //{
        //    //    _dataGridList = new List<CertificateModel>();
        //    //    Debug.WriteLine("No File Found - New list made");
        //    //}

        //    //UpdateRowcount();

        //}

        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //string FilePath = Environment.ExpandEnvironmentVariables(Path.Combine(FolderPath, "sites.json"));


        //    //if (sslDataGrid.RowCount > 0)
        //    //{
        //    //    string updatedJson = JsonSerializer.Serialize(_dataGridList, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //    //    File.WriteAllText(FilePath, updatedJson);
        //    //    
        //    //}
        //    //else 
        //    //{

        //    //    Debug.WriteLine("No rows in datagrid. No json file will be created.");
        //    //}
        //}


        //public void AddSiteConfirmClick(object? sender, EventArgs e)
        //{
        //    //Takes user input and builds a URI using the Uri Builder I defined so all links come out the same.

        //    //if (!UserInput.Contains(":")) 
        //    //{
        //    //    UserInput = "https://" + UserInput;
        //    //}

        //    //if (Uri.IsWellFormedUriString(UserInput, UriKind.Absolute)) 
        //    //{
        //    //    FinalUri = new Uri(UserInput);
        //    //}

        //    //if (FinalUri.Scheme != "https")
        //    //{
        //    //    /*Catches Formating of the User input and prompts a MessageBox with an Ok button
        //    //      this is to let the user know the address they entered is not formatted correctly or has illegal charachters that cannot be in a web address.*/
        //    //    MessageBox.Show("An Error Occured:\n\nWeb Address entered is incorrectly formatted or has illegal charctaers. Hostname could not be parsed from Web Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //}

        //    //DialogResult = DialogResult.OK;
        //    //Close();
        //}


    }
}
