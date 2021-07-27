using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        //private string BaseApiUrl = "https://localhost:44350/api/";
        private string BaseApiUrl = string.Empty;
        public Form1()
        {
            InitializeComponent();
            lblErrorText.Visible = false;
            ResetControls();
            BaseApiUrl = Properties.Settings.Default.BaseApiUrl;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            lblErrorText.Visible = false;
            ResetControls();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblErrorText.Visible = false;
            using (var client = new HttpClient())
            {
                //set up client
                client.BaseAddress = new Uri(BaseApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                OrderDTO order = new OrderDTO();
                order.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                order.OrderText = txtOrderText.Text;

                var jsonString = JsonConvert.SerializeObject(order);
                try
                {
                    HttpResponseMessage Res = client.PostAsync("orders", new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;
                    var result = Res.Content.ReadAsStringAsync();
                    lblErrorText.Visible = true;
                    lblErrorText.Text = result.Result.ToString();
                    lblErrorText.ForeColor = Color.Green;

                    ResetControls();
                }
                catch (Exception ex)
                {
                    lblErrorText.Visible = true;
                    lblErrorText.Text = ex.Message;
                    lblErrorText.ForeColor = Color.Red;
                }
            }
        }

        private void ResetControls()
        {
            txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            txtOrderText.Text = string.Empty;
        }
    }
}