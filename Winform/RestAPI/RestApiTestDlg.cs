using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExamples.RestAPI
{
	public partial class RestApiTestDlg : Form
	{
		public class NewsContent
		{
			public string author { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string url { get; set; }
			public string urlToImage { get; set; }
			public DateTime publishedAt { get; set; }
			public string content { get; set; }
		}

		public class ResponseContent
		{
			public string status { get; set; }
			public int totalResults { get; set; }
			public List<NewsContent> articles { get; set; }
		}

		public RestApiTestDlg()
		{
			InitializeComponent();
		}

		private void btnGetNews_Click(object sender, EventArgs e)
		{
			string baseUrl = @"http://newsapi.org/v2";

			RestClient client = new RestClient(baseUrl);
			var request = new RestRequest("/top-headlines", Method.GET);

			request.AddQueryParameter("country", "kr");
			request.AddQueryParameter("apiKey", "8a973bcb078b4731ae1e7543d1acdd88");

			IRestResponse response = client.Get(request);
			var content = response.StatusCode.ToString();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				ResponseContent news = JsonConvert.DeserializeObject<ResponseContent>(response.Content);
				txtResult.Text = response.Content;

				dgvNews.DataSource = news.articles;
			}
		}
	}
}
