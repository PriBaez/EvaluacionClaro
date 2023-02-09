using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace evaluacionClaro.Services
{
    public class BooksService : IBooksService
    {
        private string Baseurl = "https://localhost:7171/";
        

        public BooksService()
        {
        }

        public IEnumerable<Books> GetAllBooks()
        {
            List<Books> booklist = new List<Books>();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/Books").Result;

                if (res.IsSuccessStatusCode)
                {
                    
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    
                   return booklist = JsonConvert.DeserializeObject<List<Books>>(EmpResponse);
                } else{
                    return booklist;
                }
            }

               
        }

        public Books GetBookById(int BookId)
        {
            Books book;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.GetAsync("api/Books/" + BookId).Result;

                if (res.IsSuccessStatusCode)
                {
                    
                    var bookRes = res.Content.ReadAsStringAsync().Result;
                    
                   return book = JsonConvert.DeserializeObject<Books>(bookRes);
                } 
                else{
                    return new Books();
                }
            }
        }

        public bool Insert(Books book)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postService = client.PostAsJsonAsync<Books>("api/Books", book).Result;

                
                if(postService.IsSuccessStatusCode)
                {
                    return true;
                }
                else{
                    return false;
                }
            }

        }

        public bool Update(Books book, int id)
        {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var putService = client.PutAsJsonAsync<Books>($"api/Books/{id}", book).Result;
                   
                    
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

                    var deleteService = client.DeleteAsync($"api/Books/{id}").Result;

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

