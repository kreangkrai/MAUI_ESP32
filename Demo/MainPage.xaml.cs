using Demo.Model;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace Demo;

public partial class MainPage : ContentPage
{
    List<DeviceModel> devices = new List<DeviceModel>();
	public MainPage()
	{
		InitializeComponent();
        GetDevices();
	}

    async void GetDevices()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.GetAsync("http://172.20.10.3:8082/datas");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        devices = JsonConvert.DeserializeObject<List<DeviceModel>>(responseBody);

        if (devices != null )
        {
            DeviceModel device1 = devices.Where(w=>w.device == "Sensor1").FirstOrDefault();
            if (device1.status == true)
            {
                BtnDevice1.Text = "ON";
                BtnDevice1.BackgroundColor = Colors.ForestGreen;
            }
            else
            {
                BtnDevice1.Text = "OFF";
                BtnDevice1.BackgroundColor = Colors.Red;
            }

            DeviceModel device2 = devices.Where(w => w.device == "Sensor2").FirstOrDefault();
            if (device2.status == true)
            {
                BtnDevice2.Text = "ON";
                BtnDevice2.BackgroundColor = Colors.ForestGreen;
            }
            else
            {
                BtnDevice2.Text = "OFF";
                BtnDevice2.BackgroundColor = Colors.Red;
            }

            DeviceModel device3 = devices.Where(w => w.device == "Sensor3").FirstOrDefault();
            if (device3.status == true)
            {
                BtnDevice3.Text = "ON";
                BtnDevice3.BackgroundColor = Colors.ForestGreen;
            }
            else
            {
                BtnDevice3.Text = "OFF";
                BtnDevice3.BackgroundColor = Colors.Red;
            }
        } 
    }

    private async void BtnDevice1_Clicked(object sender, EventArgs e)
    {
        if (BtnDevice1.Text == "ON")
        {
            DeviceModel device = new DeviceModel()
            {
                id = 1,
                device = "Sensor1",
                status = false,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice1.Text = "OFF";
            BtnDevice1.BackgroundColor = Colors.Red;
        }
        else
        {
            DeviceModel device = new DeviceModel()
            {
                id = 1,
                device = "Sensor1",
                status = true,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice1.Text = "ON";
            BtnDevice1.BackgroundColor = Colors.ForestGreen;
        }
    }

    private async void BtnDevice2_Clicked(object sender, EventArgs e)
    {
        if (BtnDevice2.Text == "ON")
        {
            DeviceModel device = new DeviceModel()
            {
                id = 2,
                device = "Sensor2",
                status = false,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice2.Text = "OFF";
            BtnDevice2.BackgroundColor = Colors.Red;
        }
        else
        {
            DeviceModel device = new DeviceModel()
            {
                id = 2,
                device = "Sensor2",
                status = true,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice2.Text = "ON";
            BtnDevice2.BackgroundColor = Colors.ForestGreen;
        }
    }

    private async void BtnDevice3_Clicked(object sender, EventArgs e)
    {
        if (BtnDevice3.Text == "ON")
        {
            DeviceModel device = new DeviceModel()
            {
                id = 3,
                device = "Sensor3",
                status = false,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice3.Text = "OFF";
            BtnDevice3.BackgroundColor = Colors.Red;
        }
        else
        {
            DeviceModel device = new DeviceModel()
            {
                id = 3,
                device = "Sensor3",
                status = true,
                date = DateTime.Now
            };
            HttpClient client = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(device);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://172.20.10.3:8082/datas", httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            BtnDevice3.Text = "ON";
            BtnDevice3.BackgroundColor = Colors.ForestGreen;
        }
    }
}

