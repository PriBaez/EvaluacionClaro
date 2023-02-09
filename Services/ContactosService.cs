using evaluacionClaro.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace evaluacionClaro.Services
{
    public class ContactosService : IContactosService
    {
        private string Baseurl = "https://localhost:7171/";
        

        public ContactosService()
        {
        }

        public IEnumerable<Contactos> GetAllContactos()
        {
            List<Contactos> booklist = new List<Contactos>();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/Contactos").Result;

                if (res.IsSuccessStatusCode)
                {
                    
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    
                   return booklist = JsonConvert.DeserializeObject<List<Contactos>>(EmpResponse);
                } else{
                    return booklist;
                }
            }

               
        }

        public Contactos GetContactosById(int id)
        {
            Contactos book;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/Contactos/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    
                    var bookRes = res.Content.ReadAsStringAsync().Result;
                    
                   return book = JsonConvert.DeserializeObject<Contactos>(bookRes);
                } 
                else{
                    return new Contactos();
                }
            }
        }

        public bool Insert(Contactos contacto)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postService = client.PostAsJsonAsync<Contactos>("api/Contactos", contacto).Result;

                
                if(postService.IsSuccessStatusCode)
                {
                    return true;
                }
                else{
                    return false;
                }
            }

        }

        public bool Update(Contactos book, int id)
        {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var putService = client.PutAsJsonAsync<Contactos>($"api/Contactos/{id}", book).Result;
                   
                    
                    if(putService.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else{
                        return false;
                    }
                    }
        }

        public bool Delete(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var deleteService = client.DeleteAsync($"api/Contactos/{id}").Result;

                    if(deleteService.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else{
                        return false;
                    }
                }

            }
        }

    }

